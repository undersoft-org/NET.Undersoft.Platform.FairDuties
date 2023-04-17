﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltimatR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
   using Domain;
    
    public class CountryLanguageMapping : EntityTypeMapping<CountryLanguage>
    {
        private const string TABLE_NAME = "CountryLanguages";

        public override void Configure(EntityTypeBuilder<CountryLanguage> builder)
        {
            builder.ToTable(TABLE_NAME, DbSchema.LocalSchema);

            modelBuilder.LinkToSet<CountryLanguage, Country>(
                nameof(Country.Language),
                nameof(CountryLanguage.Countries), ExpandSite.OnLeft);
        }
    }
}