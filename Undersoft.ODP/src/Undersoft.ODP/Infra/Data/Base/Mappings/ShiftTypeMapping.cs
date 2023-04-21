using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltimatR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class ShiftTypeMapping : EntityTypeMapping<ShiftType>
    {
        const string TABLE_NAME = "ShiftTypes";

        public override void Configure(EntityTypeBuilder<ShiftType> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            modelBuilder
                .LinkSetToSet<ShiftType, Attribute>(ExpandSite.OnRight)
                .LinkSetToSet<ShiftType, User>(ExpandSite.OnLeft)
                .LinkSetToSet<ShiftType, Team>(ExpandSite.OnLeft)
                .LinkSetToSet<ShiftType, Organization>(ExpandSite.OnLeft)
                .LinkToSet<ShiftType, Shift>(ExpandSite.OnLeft)
                .LinkSetToSet<ShiftType, ShiftType>(
                    nameof(ShiftType.RelatedTo),
                    nameof(ShiftType.RelatedFrom),
                    ExpandSite.OnRight
                )
                 .LinkSetToSet<ShiftType, ShiftType>(
                    nameof(ShiftType.DependentOn),
                    "ShiftTypes",
                    nameof(ShiftType.DependentBy),
                    "ShiftTypeDependencies",
                    ExpandSite.OnRight
                )
                   .LinkSetToSet<ShiftType, ShiftType>(
                    nameof(ShiftType.OptionalTo),
                    "ShiftTypes",
                    nameof(ShiftType.OptionalFrom),
                    "ShiftTypeOptionals",
                    ExpandSite.OnRight
                );
        }
    }
}
