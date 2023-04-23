using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class SettingMapping : EntityTypeMapping<Option>
    {
        const string TABLE_NAME = "Settings";

        public override void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            builder.Property(p => p.Name).HasMaxLength(100).HasColumnType("varchar").IsRequired();
        }
    }
}