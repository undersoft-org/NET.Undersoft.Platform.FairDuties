using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class EstamteMapping : EntityTypeMapping<Estimate>
    {
        const string TABLE_NAME = "FrameRates";

        public override void Configure(EntityTypeBuilder<Estimate> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            modelBuilder
                .LinkToSet<Group, Estimate>(ExpandSite.OnRight)
                .LinkToSet<Member, Estimate>(ExpandSite.OnRight)
                .LinkToSet<Union, Estimate>(ExpandSite.OnRight)
                .LinkToSet<Asset, Estimate>(ExpandSite.OnLeft)
                  .LinkSetToSet<Estimate, Estimate>(
                    nameof(Estimate.DependentOn),
                    "FrameRates",
                    nameof(Estimate.DependentBy),
                    "FrameRateDependencies",
                    ExpandSite.OnRight
                )
                   .LinkSetToSet<Estimate, Estimate>(
                    nameof(Estimate.OptionalTo),
                    "FrameRates",
                    nameof(Estimate.OptionalFrom),
                    "FrameRateOptionals",
                    ExpandSite.OnRight
                );
        }
    }
}
