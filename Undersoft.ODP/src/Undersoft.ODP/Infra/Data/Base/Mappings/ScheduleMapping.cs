using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltimatR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class ScheduleMapping : EntityTypeMapping<Schedule>
    {
        const string TABLE_NAME = "Schedules";

        public override void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable(TABLE_NAME, DbSchema.LocalSchema);

            builder.Property(p => p.Name).HasMaxLength(100).HasColumnType("varchar").IsRequired();
        }
    }
}