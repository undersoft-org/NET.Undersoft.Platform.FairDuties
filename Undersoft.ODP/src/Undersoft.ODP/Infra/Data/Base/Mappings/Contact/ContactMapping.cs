﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
   using Domain;
    
    public class ContactMapping : EntityTypeMapping<Contact>
    {
        private const string TABLE_NAME = "Contacts";

        public override void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            modelBuilder.LinkToSet<Contact, Address>(
                nameof(Address.Contact),
                nameof(Contact.Addresses), ExpandSite.OnRight);
        }
    }
}