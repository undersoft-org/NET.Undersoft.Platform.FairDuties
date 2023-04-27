using System.Uniques;

namespace Undersoft.AEP.Raw
{
    public class Resource : UniqueObject
    {
        public double Checksum { get; set; }

        public long AssetId { get; set; }

        public long EstimateId { get; set; }

        public long UsageSetId { get; set; }

        public long SourceId { get; set; }
    }
}
