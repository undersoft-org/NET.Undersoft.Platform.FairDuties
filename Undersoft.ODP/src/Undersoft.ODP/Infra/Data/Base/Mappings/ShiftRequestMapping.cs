using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltimatR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class ShiftRequestMapping : EntityTypeMapping<ShiftRequest>
    {
        const string TABLE_NAME = "ShiftRequests";

        public override void Configure(EntityTypeBuilder<ShiftRequest> builder)
        {
            builder.ToTable(TABLE_NAME, DbSchema.LocalSchema);           

            builder.Property(p => p.Reason)
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();

        }
    }
}
