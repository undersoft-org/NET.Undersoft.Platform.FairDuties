using RadicalR;

namespace Undersoft.ODP.Api
{
    public class BasicDeviceSession : Dto
    {
        public long DeviceId { get; set; }

        public ushort Port { get; set; }

        public string MACAddress { get; set; }

        public DateTime ConnectedOn { get; set; }

        public int DurationTime { get; set; }
    }
}
