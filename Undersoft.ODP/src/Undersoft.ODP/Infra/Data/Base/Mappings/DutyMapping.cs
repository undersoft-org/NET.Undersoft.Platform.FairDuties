using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class DutyMapping : EntityTypeMapping<Duty>
    {
        const string TABLE_NAME = "Duties";

        public override void Configure(EntityTypeBuilder<Duty> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            modelBuilder
                .LinkOneToSet<Vector, Duty>(
                    nameof(Duty.Vector),
                    nameof(Vector.Duties),
                    ExpandSite.OnRight
                )
                .LinkSetToSet<Duty, Vector>(
                    nameof(Vector.DutyViews),
                    nameof(Duty.VectorViews),
                    ExpandSite.OnLeft
                )
                .LinkSetToSet<Duty, Request>(                   
                    nameof(Request.Duties),
                    nameof(Duty.Requests),
                    ExpandSite.OnLeft
                );
        }
    }
}
