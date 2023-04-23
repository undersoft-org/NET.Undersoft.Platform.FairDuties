using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class PropertyMapping : EntityTypeMapping<Property>
    {
        const string TABLE_NAME = "Properties";

        public override void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            builder.Property(p => p.Key).HasMaxLength(100).HasColumnType("varchar").IsRequired();

            builder.Property(p => p.Value).HasMaxLength(255).HasColumnType("varchar").IsRequired();

            modelBuilder
              .LinkSetToSet<Property, Property>(
                  nameof(Property.RelatedTo),
                  nameof(Property.RelatedFrom),
                  ExpandSite.OnRight
              );
        }
    }
}