using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class AssetMapping : EntityTypeMapping<Asset>
    {
        const string TABLE_NAME = "Assets";

        public override void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            modelBuilder
                .LinkSetToSet<Asset, Member>(ExpandSite.OnLeft)
                .LinkSetToSet<Asset, Group>(ExpandSite.OnLeft)
                .LinkSetToSet<Asset, Union>(ExpandSite.OnLeft)
                .LinkSetToSet<Asset, Property>(
                    nameof(Property.Assets),
                    nameof(Asset.Properties),
                    ExpandSite.OnRight
                )                
                .LinkOneToSet<Asset, Duty>(
                    nameof(Duty.Asset),
                    nameof(Asset.Duties),
                    ExpandSite.OnLeft
                )
                .LinkSetToSet<Asset, Asset>(
                    nameof(Asset.RelatedTo),
                    nameof(Asset.RelatedFrom),
                    ExpandSite.OnRight
                )
                .LinkSetToSet<Asset, Asset>(
                    nameof(Asset.DependentOn),
                    "Assets",
                    nameof(Asset.DependentBy),
                    "AssetDependencies",
                    ExpandSite.OnRight
                )
                .LinkSetToSet<Asset, Asset>(
                    nameof(Asset.OptionalTo),
                    "Assets",
                    nameof(Asset.OptionalFrom),
                    "AssetOptionals",
                    ExpandSite.OnRight
                );
        }
    }
}
