using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class ShiftMapping : EntityTypeMapping<Shift>
    {
        const string TABLE_NAME = "Shifts";

        public override void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            modelBuilder
                .LinkToSet<Schedule, Shift>(ExpandSite.OnRight)
                .LinkSetToSet<Shift, Schedule>(nameof(Schedule.ShiftViews), nameof(Shift.ScheduleViews), ExpandSite.OnLeft)
                .LinkSetToSet<Shift, ShiftRequest>(ExpandSite.OnLeft);
        }
    }
}
