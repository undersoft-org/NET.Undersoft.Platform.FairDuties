using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltimatR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class PlanMapping : EntityTypeMapping<Plan>
    {
        const string TABLE_NAME = "Plans";

        public override void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            builder.Property(p => p.Name)
              .HasMaxLength(50)
              .HasColumnType("varchar")
              .IsRequired();

            modelBuilder
                .LinkSetToSet<Organization, Plan>(ExpandSite.OnLeft)
                .LinkSetToSet<User, Plan>(ExpandSite.OnLeft)
                .LinkSetToSet<ShiftType, Plan>(ExpandSite.OnLeft)
                .LinkSetToSet<Team, Plan>(ExpandSite.OnLeft);
        }
    }
}
