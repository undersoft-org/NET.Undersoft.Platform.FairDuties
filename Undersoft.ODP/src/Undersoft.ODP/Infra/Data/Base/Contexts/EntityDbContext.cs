using Microsoft.EntityFrameworkCore;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Contexts
{
    using Domain;
    using Mappings;

    public class EntryDbContext : EntityDbContext<IEntryStore, EntryDbContext>
    {
        public EntryDbContext(DbContextOptions<EntryDbContext> options) : base(options) { }
    }

    public class ReportDbContext : EntityDbContext<IReportStore, ReportDbContext>
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> options) : base(options) { }
    }

    public partial class EntityDbContext<TStore, TContext> : DataBaseContext<TStore>
        where TStore : IDataStore
        where TContext : DbContext
    {
        public EntityDbContext(DbContextOptions<TContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyIdentity<TContext>()
                .ApplyMapping(new TeamMapping())
                .ApplyMapping(new ShiftTypeMapping())
                .ApplyMapping(new ShiftRateMapping())
                .ApplyMapping(new ShiftMapping())
                .ApplyMapping(new ShiftRequestMapping())
                .ApplyMapping(new PlanMapping())
                .ApplyMapping(new ScheduleMapping())
                .ApplyMapping(new ConfigurationMapping())
                .ApplyMapping(new OrganizationMapping())
                .ApplyMapping(new DeviceMapping())
                .ApplyMapping(new DeviceSessionMapping())
                .ApplyMapping(new UserMapping())
                .ApplyMapping(new UserRoleMapping())
                .ApplyMapping(new PersonalMapping())
                .ApplyMapping(new AddressMapping())
                .ApplyMapping(new ContactMapping())
                .ApplyMapping(new CountryMapping())
                .ApplyMapping(new CountryStateMapping())
                .ApplyMapping(new CountryLanguageMapping())
                .ApplyMapping(new CurrencyMapping())
                .ApplyMapping(new AttributeMapping());

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Attribute> Attributes { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Currency> Currencies { get; set; }

        public virtual DbSet<CountryLanguage> CountryLanguages { get; set; }

        public virtual DbSet<CountryState> CountryStates { get; set; }

        public virtual DbSet<Personal> Personals { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<Shift> Shifts { get; set; }

        public virtual DbSet<ShiftType> ShiftTypes { get; set; }

        public virtual DbSet<ShiftRate> ShiftRatings { get; set; }

        public virtual DbSet<ShiftRequest> ShiftRequests { get; set; }

        public virtual DbSet<Schedule> Schedules { get; set; }

        public virtual DbSet<Plan> Plans { get; set; }

        public virtual DbSet<Setting> Settings { get; set; }

        public virtual DbSet<Organization> Organizations { get; set; }

        public virtual DbSet<Configuration> Configurations { get; set; }

        public virtual DbSet<Device> Devices { get; set; }

        public virtual DbSet<DeviceSession> DeviceSessions { get; set; }
    }
}
