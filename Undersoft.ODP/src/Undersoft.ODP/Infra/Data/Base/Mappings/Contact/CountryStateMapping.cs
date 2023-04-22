using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
   using Domain;
    
    public class CountryStateMapping : EntityTypeMapping<CountryState>
    {
        private const string TABLE_NAME = "CountryStates";

        public override void Configure(EntityTypeBuilder<CountryState> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            modelBuilder.LinkToSet<Country, CountryState>(
                nameof(CountryState.Country),
                nameof(Country.States), ExpandSite.OnRight);

            modelBuilder.LinkToSet<CountryState, Address>(
                nameof(Address.State),
                nameof(CountryState.Addresses), ExpandSite.OnLeft);
        }
    }
}