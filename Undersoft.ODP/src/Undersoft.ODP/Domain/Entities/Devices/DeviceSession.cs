using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using UltimatR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public partial class DeviceSession : Entity
    {
        public long? DeviceId { get; set; }
        [JsonIgnore] public virtual Device Device { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        public IPHostEntry Host { get; set; }

        public ushort Port { get; set; }

        public string MACAddress { get; set; }

        public DateTime ConnectedOn { get; set; }

        public int DurationTime { get; set; }
    }
}
