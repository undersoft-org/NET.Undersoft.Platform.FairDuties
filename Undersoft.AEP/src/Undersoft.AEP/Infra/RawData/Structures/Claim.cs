using RadicalR;

namespace Undersoft.AEP
{
    public class Claim : Identifiable
    {
        public double Checksum { get; set; }

        public long AllocTypeId { get; set; }

        public long AllocRateId { get; set; }

        public long AllocSetId { get; set; }
    }
}
