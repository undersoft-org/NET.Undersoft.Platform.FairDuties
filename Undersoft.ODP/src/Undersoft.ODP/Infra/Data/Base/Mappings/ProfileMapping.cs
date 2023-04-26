using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class ProfileMapping : EntityTypeMapping<Profile>
    {
        string TABLE_NAME = "Profiles";

        public override void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            builder.Property(p => p.Email).HasMaxLength(100).HasColumnType("varchar").IsRequired();

            builder.Property(p => p.PhoneNumber).HasMaxLength(50).HasColumnType("varchar");

            builder
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();

            builder
                .Property(p => p.LastName)
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(p => p.FullName).HasMaxLength(100).HasColumnType("varchar");

            modelBuilder
                .LinkSetToSet<Profile, Property>(
                    nameof(Property.Profiles),
                    nameof(Profile.Properties),
                    ExpandSite.OnRight
                )
                .LinkSetToSet<Profile, Locale>(ExpandSite.OnRight)
                .LinkSetToSet<Profile, Client>(ExpandSite.OnRight);
        }
    }
}
