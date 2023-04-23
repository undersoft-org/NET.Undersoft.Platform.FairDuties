using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class GroupMapping : EntityTypeMapping<Group>
    {
        const string TABLE_NAME = "Groups";

        public override void Configure(EntityTypeBuilder<Group> builder)
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
                .LinkToSet<Group, Vector>(nameof(Vector.GroupView), nameof(Group.ScheduleViews), ExpandSite.OnRight)
                .LinkToSingle<Group, Vector>(nameof(Vector.Group), nameof(Group.Schedule), ExpandSite.OnRight)
                .LinkToSet<Group, Duty>(ExpandSite.OnRight)
                .LinkToSet<Group, Request>(ExpandSite.OnRight)
                .LinkSetToSet<Group, Property>(ExpandSite.OnRight)
                .LinkToSingle<Group, Setup>(ExpandSite.OnRight);
        }
    }
}
