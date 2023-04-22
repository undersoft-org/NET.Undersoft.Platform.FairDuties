using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class TeamMapping : EntityTypeMapping<Team>
    {
        const string TABLE_NAME = "Teams";

        public override void Configure(EntityTypeBuilder<Team> builder)
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
                .LinkToSet<Team, Schedule>(nameof(Schedule.TeamView), nameof(Team.ScheduleViews), ExpandSite.OnRight)
                .LinkToSingle<Team, Schedule>(nameof(Schedule.Team), nameof(Team.Schedule), ExpandSite.OnRight)
                .LinkToSet<Team, Shift>(ExpandSite.OnRight)
                .LinkToSet<Team, ShiftRequest>(ExpandSite.OnRight)
                .LinkSetToSet<Team, Attribute>(ExpandSite.OnRight)
                .LinkToSingle<Team, Configuration>(ExpandSite.OnRight);
        }
    }
}
