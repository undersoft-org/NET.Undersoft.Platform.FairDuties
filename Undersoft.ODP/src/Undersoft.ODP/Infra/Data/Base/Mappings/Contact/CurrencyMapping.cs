using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class CurrencyMapping : EntityTypeMapping<Currency>
    {
        const string TABLE_NAME = "Currencies";

        public override void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);
        }
    }
}
