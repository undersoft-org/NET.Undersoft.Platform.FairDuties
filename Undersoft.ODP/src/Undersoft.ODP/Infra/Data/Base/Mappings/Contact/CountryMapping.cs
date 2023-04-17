using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltimatR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
   using Domain;
    
    public class CountryMapping : EntityTypeMapping<Country>
    {
        private const string TABLE_NAME = "Countries";

        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable(TABLE_NAME, DbSchema.LocalSchema);
            
            modelBuilder.LinkToSet<Currency, Country>(
            nameof(Country.Currency),
            nameof(Currency.Countries), ExpandSite.OnLeft);

            modelBuilder.LinkToSet<Country, Address>(
              nameof(Address.Country),
              nameof(Country.Addresses), ExpandSite.OnLeft);
        }
    }
}