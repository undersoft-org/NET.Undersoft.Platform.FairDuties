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

            builder.Property(p => p.Name).HasMaxLength(100).HasColumnType("varchar").IsRequired();

            builder
                .Property(p => p.ShortName)
                .HasMaxLength(32)
                .HasColumnType("varchar")
                .IsRequired();

            modelBuilder
                .LinkOneToSet<Group, Request>(ExpandSite.OnRight)
                .LinkOneToOne<Group, Setup>(ExpandSite.OnRight)
                .LinkOneToSet<Group, Vector>(
                    nameof(Vector.GroupView),
                    nameof(Group.VectorViews),
                    ExpandSite.OnRight
                )
                .LinkOneToOne<Group, Vector>(
                    nameof(Vector.Group),
                    nameof(Group.Vector),
                    ExpandSite.OnRight
                )
                .LinkOneToSet<Group, Duty>(
                    nameof(Duty.Group),
                    nameof(Group.Duties),
                    ExpandSite.OnRight
                )
                .LinkSetToSet<Group, Property>(
                    nameof(Property.Groups),
                    nameof(Group.Properties),
                    ExpandSite.OnRight
                );
        }
    }
}
