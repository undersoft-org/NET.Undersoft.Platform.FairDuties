using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
   using Domain;
    
    public class ContactMapping : EntityTypeMapping<Locale>
    {
        private const string TABLE_NAME = "Locales";

        public override void Configure(EntityTypeBuilder<Locale> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            modelBuilder.LinkOneToSet<Locale, Address>(
                nameof(Address.Contact),
                nameof(Locale.Addresses), ExpandSite.OnRight);
        }
    }
}