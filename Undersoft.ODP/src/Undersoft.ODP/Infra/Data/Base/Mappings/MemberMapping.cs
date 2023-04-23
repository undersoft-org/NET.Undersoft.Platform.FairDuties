using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class MemberMapping : EntityTypeMapping<Member>
    {
        const string TABLE_NAME = "Members";

        public override void Configure(EntityTypeBuilder<Member> builder)
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
                .ApplyIdentifiers<Member>()

                .LinkSetToSet<Member, Property>(ExpandSite.OnRight, true)
                .LinkSetToSet<Member, Group>(ExpandSite.OnLeft)
                .LinkToSingle<Member, Setup>(ExpandSite.OnRight)
                .LinkToSet<Member, Role>(ExpandSite.OnRight)
                .LinkToSet<Member, Duty>(ExpandSite.OnRight)
                .LinkToSet<Member, Request>(ExpandSite.OnRight)
                .LinkToSingle<Profile, Member>(ExpandSite.OnLeft)
                .LinkToSet<Member, Group>(
                nameof(Group.Leadership),
                nameof(Member.Leaderships), ExpandSite.OnRight);
        }
    }
}
