using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class ClientMapping : EntityTypeMapping<Client>
    {
        const string TABLE_NAME = "Clients";

        public override void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            builder.Property(p => p.Name).HasMaxLength(100).HasColumnType("varchar").IsRequired();

            modelBuilder.ApplyIdentifiers<Client>();

            modelBuilder.LinkOneToSet<Client, Session>(nameof(Session.Device), nameof(Client.Sessions), ExpandSite.OnRight);
        }
    }
}