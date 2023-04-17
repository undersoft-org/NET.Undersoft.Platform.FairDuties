using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using UltimatR;


namespace Undersoft.ODP.Domain
{
    [DataContract]
    public partial class Device : Entity
    {
        public string Name { get; set; }

        public string SerialNumber { get; set; }

        public string HostName { get; set; }

        public string Model { get; set; }

        public string SystemInfo { get; set; }

        public string SystemVersion { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboSet<Personal> Personals { get; set; }

        public virtual DboToSet<DeviceSession> Sessions { get; set; }

        public virtual Identifiers<Device> Identifiers { get; set; }
    }
}
