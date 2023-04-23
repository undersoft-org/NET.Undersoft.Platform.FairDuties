using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class RequestMapping : EntityTypeMapping<Request>
    {
        const string TABLE_NAME = "Requests";

        public override void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);           

            builder.Property(p => p.Reason)
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();

        }
    }
}
