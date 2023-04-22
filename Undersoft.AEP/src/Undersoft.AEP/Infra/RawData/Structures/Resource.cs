using RadicalR;

namespace Undersoft.AEP
{
    public class Resource : Identifiable
    {
        public double Checksum { get; set; }

        public long AllocTypeId { get; set; }

        public long AllocRateId { get; set; }

        public long AllocSetId { get; set; }

        public long AssetId { get; set; }
    }
}
