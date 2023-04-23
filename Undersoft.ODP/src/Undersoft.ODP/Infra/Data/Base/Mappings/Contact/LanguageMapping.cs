using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class LanguageMapping : EntityTypeMapping<Language>
    {
        private const string TABLE_NAME = "Languages";

        public override void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            modelBuilder.LinkToSet<Language, Country>(
                nameof(Country.Language),
                nameof(Language.Countries), ExpandSite.OnLeft);
        }
    }
}