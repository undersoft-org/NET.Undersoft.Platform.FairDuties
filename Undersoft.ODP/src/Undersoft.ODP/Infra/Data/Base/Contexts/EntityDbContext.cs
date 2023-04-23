﻿using Microsoft.EntityFrameworkCore;
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
                .ApplyMapping(new GroupMapping())
                .ApplyMapping(new AssetMapping())
                .ApplyMapping(new EstamteMapping())
                .ApplyMapping(new DutyMapping())
                .ApplyMapping(new RequestMapping())
                .ApplyMapping(new PlanMapping())
                .ApplyMapping(new VectorMapping())
                .ApplyMapping(new SetupMapping())
                .ApplyMapping(new UnionMapping())
                .ApplyMapping(new ClientMapping())
                .ApplyMapping(new SessionMapping())
                .ApplyMapping(new MemberMapping())
                .ApplyMapping(new RoleMapping())
                .ApplyMapping(new ProfileMapping())
                .ApplyMapping(new AddressMapping())
                .ApplyMapping(new ContactMapping())
                .ApplyMapping(new CountryMapping())
                .ApplyMapping(new CountryStateMapping())
                .ApplyMapping(new LanguageMapping())
                .ApplyMapping(new CurrencyMapping())
                .ApplyMapping(new PropertyMapping());

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Property> Properties { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Currency> Currencies { get; set; }

        public virtual DbSet<Language> Languages { get; set; }

        public virtual DbSet<CountryState> CountryStates { get; set; }

        public virtual DbSet<Profile> Profiles { get; set; }

        public virtual DbSet<Member> Members { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Duty> Duties { get; set; }

        public virtual DbSet<Asset> Assets { get; set; }

        public virtual DbSet<Estimate> Estimates { get; set; }

        public virtual DbSet<Request> Requests { get; set; }

        public virtual DbSet<Vector> Vectors { get; set; }

        public virtual DbSet<Vertex> Vertices { get; set; }

        public virtual DbSet<Option> Options { get; set; }

        public virtual DbSet<Union> Unions { get; set; }

        public virtual DbSet<Setup> Setups { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }
    }
}
