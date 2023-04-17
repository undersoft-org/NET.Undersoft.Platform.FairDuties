using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltimatR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class ShiftRateMapping : EntityTypeMapping<ShiftRate>
    {
        const string TABLE_NAME = "ShiftRates";

        public override void Configure(EntityTypeBuilder<ShiftRate> builder)
        {
            builder.ToTable(TABLE_NAME, DbSchema.LocalSchema);

            modelBuilder
                .LinkToSet<Team, ShiftRate>(ExpandSite.OnRight)
                .LinkToSet<User, ShiftRate>(ExpandSite.OnRight)
                .LinkToSet<Organization, ShiftRate>(ExpandSite.OnRight)
                .LinkToSet<ShiftType, ShiftRate>(ExpandSite.OnLeft)
                  .LinkSetToSet<ShiftRate, ShiftRate>(
                    nameof(ShiftRate.DependentOn),
                    "ShiftRates",
                    nameof(ShiftRate.DependentBy),
                    "ShiftRateDependencies",
                    ExpandSite.OnRight
                )
                   .LinkSetToSet<ShiftRate, ShiftRate>(
                    nameof(ShiftRate.OptionalTo),
                    "ShiftRates",
                    nameof(ShiftRate.OptionalFrom),
                    "ShiftRateOptionals",
                    ExpandSite.OnRight
                );
        }
    }
}
