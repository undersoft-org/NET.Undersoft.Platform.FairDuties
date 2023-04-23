using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class RoleMapping : EntityTypeMapping<Role>
    {
        const string TABLE_NAME = "Roles";

        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            builder
            .Property(p => p.Name)
            .HasMaxLength(64)
            .HasColumnType("varchar")
            .IsRequired();
        }
    }
}
