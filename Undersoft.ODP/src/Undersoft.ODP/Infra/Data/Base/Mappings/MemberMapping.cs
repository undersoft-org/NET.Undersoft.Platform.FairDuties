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
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            builder.Property(p => p.Name).HasMaxLength(64).HasColumnType("varchar").IsRequired();

            builder.Property(p => p.Email).HasMaxLength(100).HasColumnType("varchar").IsRequired();

            builder.Property(p => p.PhoneNumber).HasMaxLength(50).HasColumnType("varchar");

            modelBuilder
                .ApplyIdentifiers<Member>()
                .LinkSetToSet<Member, Property>(
                    nameof(Property.Members),
                    nameof(Member.Properties),
                    ExpandSite.OnRight
                )
                .LinkSetToSet<Member, Group>(ExpandSite.OnLeft)
                .LinkOneToOne<Member, Setup>(ExpandSite.OnRight)
                .LinkOneToSet<Member, Role>(ExpandSite.OnRight)
                .LinkOneToSet<Member, Duty>(
                    nameof(Duty.Member),
                    nameof(Member.Duties),
                    ExpandSite.OnRight
                )
                .LinkOneToSet<Member, Request>(ExpandSite.OnRight)
                .LinkOneToOne<Profile, Member>(ExpandSite.OnLeft)
                .LinkOneToSet<Member, Group>(
                    nameof(Group.Leadership),
                    nameof(Member.Leaderships),
                    ExpandSite.OnRight
                );
        }
    }
}
