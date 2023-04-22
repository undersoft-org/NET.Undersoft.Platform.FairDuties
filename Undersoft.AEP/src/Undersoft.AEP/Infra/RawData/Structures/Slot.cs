using RadicalR;

namespace Undersoft.AEP
{
    public class Slot : Identifiable
    {
        public float Checksum { get; set; }

        public long ClaimId { get; set; }

        public long ResourceId { get; set; }

        public long AllocId { get; set; }

        public long SequenceId { get; set; }

        public long BlockId { get; set; }

        public long FrameId { get; set; }
    }
}
