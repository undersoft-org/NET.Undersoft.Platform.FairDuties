using System.Uniques;

namespace Undersoft.AEP.Raw
{
    public class Socket : UniqueObject
    {
        public Socket() { }

        public float Checksum { get; set; }

        public long LiabilityId { get; set; }

        public long ResourceId { get; set; }

        public long UsageId { get; set; }

        public long VectorId { get; set; }

        public long SectorId { get; set; }

        public long BlockId { get; set; }
    }
}
