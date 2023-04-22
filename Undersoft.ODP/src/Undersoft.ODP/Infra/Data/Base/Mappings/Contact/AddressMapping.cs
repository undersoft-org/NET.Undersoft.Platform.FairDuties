using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
   using Domain;
    
    public class AddressMapping : EntityTypeMapping<Address>
    {
        private const string TABLE_NAME = "Addresses";

        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            builder.Property(p => p.CityName)
              .HasMaxLength(50)
              .HasColumnType("varchar")
              .IsRequired();

            builder.Property(p => p.StreetName)
              .HasMaxLength(100)
              .HasColumnType("varchar")
              .IsRequired();

            builder.Property(p => p.BuildingNumber)
             .HasMaxLength(20)
             .HasColumnType("varchar");

            builder.Property(p => p.ApartmentNumber)
             .HasMaxLength(20)
             .HasColumnType("varchar")
             .IsRequired();

            builder.Property(p => p.Postcode)
             .HasMaxLength(12)
             .HasColumnType("varchar")
             .IsRequired();

            builder.Property(p => p.Notices)
             .HasMaxLength(150)
             .HasColumnType("varchar");
        }
    }
}