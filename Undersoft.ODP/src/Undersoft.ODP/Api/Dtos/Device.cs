using UltimatR;

namespace Undersoft.ODP.Api
{
    public class Device : Dto
    {
        public string Name { get; set; }

        public string SerialNumber { get; set; }

        public string HostName { get; set; }

        public string Model { get; set; }

        public string SystemInfo { get; set; }

        public string SystemVersion { get; set; }

        public DtoSet<BasicDeviceSession> Sessions { get; set; }

        public DtoSet<IdentifierDto<Device>> Identifiers { get; set; }
    }
}
