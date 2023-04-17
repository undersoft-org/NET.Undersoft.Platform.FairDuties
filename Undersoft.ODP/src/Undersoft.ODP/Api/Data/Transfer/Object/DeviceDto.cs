using UltimatR;

namespace Undersoft.ODP.Api
{
    public class DeviceDto : Dto
    {
        public string Name { get; set; }

        public string SerialNumber { get; set; }

        public string HostName { get; set; }

        public string Model { get; set; }

        public string SystemInfo { get; set; }

        public string SystemVersion { get; set; }

        public DtoSet<BasicDeviceSessionDto> Sessions { get; set; }

        public DtoSet<DtoIdentifier<DeviceDto>> Identifiers { get; set; }
    }
}
