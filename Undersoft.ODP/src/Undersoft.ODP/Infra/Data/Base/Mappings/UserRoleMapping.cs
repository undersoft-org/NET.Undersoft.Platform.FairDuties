using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltimatR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class UserRoleMapping : EntityTypeMapping<UserRole>
    {
        const string TABLE_NAME = "UserRoles";

        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder
                .ToTable(TABLE_NAME, DbSchema.LocalSchema);

            builder
            .Property(p => p.Name)
            .HasMaxLength(64)
            .HasColumnType("varchar")
            .IsRequired();
        }
    }
}
