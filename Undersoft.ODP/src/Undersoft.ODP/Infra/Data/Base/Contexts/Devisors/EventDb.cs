using Microsoft.EntityFrameworkCore;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Contexts
{
    public partial class EventDb<TStore, TContext> : DataBaseContext<TStore> where TStore : IDataStore
        where TContext : DbContext
    {
        public EventDb(DbContextOptions<TContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyIdentity<TContext>();
            modelBuilder.ApplyMapping(new EventStoreMapping());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Event> Events { get; set; }
    }
}
