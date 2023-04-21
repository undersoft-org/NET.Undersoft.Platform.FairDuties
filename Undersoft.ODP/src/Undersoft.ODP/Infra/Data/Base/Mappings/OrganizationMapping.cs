using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltimatR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class OrganizationMapping : EntityTypeMapping<Organization>
    {
        const string TABLE_NAME = "Organizations";

        public override void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            builder.Property(p => p.Name)
              .HasMaxLength(100)
              .HasColumnType("varchar")
              .IsRequired();

            builder.Property(p => p.ShortName)
             .HasMaxLength(32)
             .HasColumnType("varchar")
             .IsRequired();

            modelBuilder
                .LinkSetToSet<Organization, Attribute>(ExpandSite.OnRight)
                .LinkSetToSet<Organization, User>(ExpandSite.OnRight)
                .LinkToSet<Organization, Team>(ExpandSite.OnRight)
                .LinkToSet<Organization, Shift>(ExpandSite.OnRight)
                .LinkToSingle<Organization, Configuration>(ExpandSite.OnRight);
        }
    }
}
