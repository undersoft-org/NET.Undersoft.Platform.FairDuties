using Microsoft.EntityFrameworkCore;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Contexts
{
    public class EventDbContext : EventDbContext<IEventStore, EventDbContext>
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }
    }

    public partial class EventDbContext<TStore, TContext> : DataBaseContext<TStore> where TStore : IDataStore
        where TContext : DbContext
    {
        public EventDbContext(DbContextOptions<TContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyIdentity<TContext>();
            modelBuilder.ApplyConfiguration(new EventStoreMapping());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Event> Events { get; set; }
    }
}
