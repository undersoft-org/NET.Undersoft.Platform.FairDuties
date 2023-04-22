using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class ConfigurationMapping : EntityTypeMapping<Configuration>
    {
        const string TABLE_NAME = "Configurations";

        public override void Configure(EntityTypeBuilder<Configuration> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            modelBuilder
               .LinkSetToSet<Configuration, Setting>(ExpandSite.OnRight);
        }
    }
}
