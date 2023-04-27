using RadicalR;

namespace Undersoft.ODP.Api
{
    public class Client : Dto
    {
        public string Name { get; set; }

        public string SerialNumber { get; set; }

        public string HostName { get; set; }

        public string Model { get; set; }

        public string SystemInfo { get; set; }

        public string SystemVersion { get; set; }

        public DtoSet<BasicSession> Sessions { get; set; }

        public DtoSet<IdentifierDto<Client>> Identifiers { get; set; }
    }
}
