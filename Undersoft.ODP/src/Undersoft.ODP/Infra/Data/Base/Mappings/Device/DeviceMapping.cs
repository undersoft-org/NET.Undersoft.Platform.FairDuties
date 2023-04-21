using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltimatR;

namespace Undersoft.ODP.Infra.Data.Base.Mappings
{
    using Domain;

    public class DeviceMapping : EntityTypeMapping<Device>
    {
        const string TABLE_NAME = "Devices";

        public override void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable(TABLE_NAME, DataBaseSchema.LocalSchema);

            builder.Property(p => p.Name).HasMaxLength(100).HasColumnType("varchar").IsRequired();

            modelBuilder.ApplyIdentifiers<Device>();

            modelBuilder.LinkToSet<Device, DeviceSession>(nameof(DeviceSession.Device), nameof(Device.Sessions), ExpandSite.OnRight);
        }
    }
}