using RadicalR;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public partial class Session : Entity
    {
        public long? DeviceId { get; set; }
        [JsonIgnore] public virtual Client Device { get; set; }

        public string Host { get; set; }

        public ushort Port { get; set; }

        public string HID { get; set; }

        public DateTime ConnectedOn { get; set; }

        public int DurationTime { get; set; }
    }
}
