using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class SetupMapping : EntityTypeMapping<Setup>
    {
        const string TABLE_NAME = "Setups";

        public override void Configure(EntityTypeBuilder<Setup> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            modelBuilder
               .LinkSetToSet<Setup, Option>(ExpandSite.OnRight);
        }
    }
}
