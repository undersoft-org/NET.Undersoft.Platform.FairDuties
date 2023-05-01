using System.Text.Json.Serialization;
using RadicalR;

namespace Undersoft.ODP.Api
{
    public class Session : Dto
    {
        public long DeviceId { get; set; }

        [JsonIgnore]
        public virtual Client CLient { get; set; }

        public ushort Port { get; set; }

        public string MACAddress { get; set; }

        public DateTime ConnectedOn { get; set; }

        public int DurationTime { get; set; }
    }
}
