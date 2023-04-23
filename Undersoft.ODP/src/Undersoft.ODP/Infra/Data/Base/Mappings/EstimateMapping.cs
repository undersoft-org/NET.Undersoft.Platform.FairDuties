using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class EstamteMapping : EntityTypeMapping<Estimate>
    {
        const string TABLE_NAME = "Estimates";

        public override void Configure(EntityTypeBuilder<Estimate> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            modelBuilder
                .LinkOneToSet<Group, Estimate>(ExpandSite.OnRight)
                .LinkOneToSet<Member, Estimate>(ExpandSite.OnRight)
                .LinkOneToSet<Union, Estimate>(ExpandSite.OnRight)
                .LinkOneToSet<Asset, Estimate>(ExpandSite.OnLeft)
                .LinkSetToSet<Estimate, Estimate>(
                    nameof(Estimate.DependentOn),
                    "Estimates",
                    nameof(Estimate.DependentBy),
                    "EstimateDependencies",
                    ExpandSite.OnRight
                )
                .LinkSetToSet<Estimate, Estimate>(
                    nameof(Estimate.OptionalTo),
                    "Estimates",
                    nameof(Estimate.OptionalFrom),
                    "EstimateOptionals",
                    ExpandSite.OnRight
                );
        }
    }
}
