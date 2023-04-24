using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class VertexMapping : EntityTypeMapping<Vertex>
    {
        const string TABLE_NAME = "Vertices";

        public override void Configure(EntityTypeBuilder<Vertex> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            builder.Property(p => p.Name).HasMaxLength(50).HasColumnType("varchar").IsRequired();

            modelBuilder
                .LinkSetToSet<Union, Vertex>(
                    nameof(Vertex.Unions),
                    nameof(Union.Vertices),
                    ExpandSite.OnLeft
                )
                .LinkSetToSet<Member, Vertex>(
                    nameof(Vertex.Members),
                    nameof(Member.Vertices),
                    ExpandSite.OnLeft
                )
                .LinkSetToSet<Asset, Vertex>(
                    nameof(Vertex.Assets),
                    nameof(Asset.Vertices),
                    ExpandSite.OnLeft
                )
                .LinkSetToSet<Group, Vertex>(
                    nameof(Vertex.Groups),
                    nameof(Group.Vertices),
                    ExpandSite.OnLeft
                );
        }
    }
}
