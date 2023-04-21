using System.Text.Json.Serialization;
using UltimatR;

namespace Undersoft.ODP.Api
{
    public class DeviceSession : Dto
    {
        public long DeviceId { get; set; }

        [JsonIgnore]
        public virtual Device Device { get; set; }

        public ushort Port { get; set; }

        public string MACAddress { get; set; }

        public DateTime ConnectedOn { get; set; }

        public int DurationTime { get; set; }
    }
}
