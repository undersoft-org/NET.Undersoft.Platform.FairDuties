using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class UserMapping : EntityTypeMapping<User>
    {
        const string TABLE_NAME = "Users";

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            builder
                .Property(p => p.UserName)
                .HasMaxLength(64)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(100)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnType("varchar");

            modelBuilder
                .ApplyIdentifiers<User>()

                .LinkSetToSet<User, Attribute>(ExpandSite.OnRight, true)
                .LinkSetToSet<User, Team>(ExpandSite.OnLeft)
                .LinkToSingle<User, Configuration>(ExpandSite.OnRight)
                .LinkToSet<User, UserRole>(ExpandSite.OnRight)
                .LinkToSet<User, Shift>(ExpandSite.OnRight)
                .LinkToSet<User, ShiftRequest>(ExpandSite.OnRight)
                .LinkToSingle<Personal, User>(ExpandSite.OnLeft)
                .LinkToSet<User, Team>(
                nameof(Team.Leadership),
                nameof(User.Leaderships), ExpandSite.OnRight);
        }
    }
}
