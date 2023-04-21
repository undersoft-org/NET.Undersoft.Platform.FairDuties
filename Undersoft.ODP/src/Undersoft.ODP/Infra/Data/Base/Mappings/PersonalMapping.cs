using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltimatR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class PersonalMapping : EntityTypeMapping<Personal>
    {
        string TABLE_NAME = "Personals";

        public override void Configure(EntityTypeBuilder<Personal> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            builder.Property(p => p.Email).HasMaxLength(100).HasColumnType("varchar").IsRequired();

            builder.Property(p => p.PhoneNumber).HasMaxLength(50).HasColumnType("varchar");

            builder.Property(p => p.FirstName).HasMaxLength(50).HasColumnType("varchar").IsRequired();

            builder.Property(p => p.LastName).HasMaxLength(50).HasColumnType("varchar").IsRequired();

            builder.Property(p => p.FullName).HasMaxLength(100).HasColumnType("varchar");

            modelBuilder
               .LinkSetToSet<Personal, Attribute>(ExpandSite.OnRight)
               .LinkSetToSet<Personal, Contact>(ExpandSite.OnRight)
               .LinkSetToSet<Personal, Device>(ExpandSite.OnRight);
        }
    }
}