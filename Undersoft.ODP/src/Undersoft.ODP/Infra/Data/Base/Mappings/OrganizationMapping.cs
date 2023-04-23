using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class UnionMapping : EntityTypeMapping<Union>
    {
        const string TABLE_NAME = "Unions";

        public override void Configure(EntityTypeBuilder<Union> builder)
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
                .LinkSetToSet<Union, Property>(ExpandSite.OnRight)
                .LinkSetToSet<Union, Member>(ExpandSite.OnRight)
                .LinkToSet<Union, Group>(ExpandSite.OnRight)
                .LinkToSet<Union, Duty>(ExpandSite.OnRight)
                .LinkToSingle<Union, Setup>(ExpandSite.OnRight);
        }
    }
}
