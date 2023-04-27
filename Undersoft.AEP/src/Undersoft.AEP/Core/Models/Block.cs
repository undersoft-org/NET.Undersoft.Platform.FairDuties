using System.Series;

namespace Undersoft.AEP.Core
{
    public class Block<TSlot, TUsage> : Catalog<TSlot> where TSlot : ISocket where TUsage : IUsage
    {
        public Block() { }

        public IVector<TSlot, TUsage> Vector { get; set; }

        public float Checksum { get; set; }

        public float Capacity { get; set; }

        public IDeck<IUsage> Usages { get; set; }

        public IDeck<ILiability> Liabilities { get; set; }

        public IDeck<IResource> Resources { get; set; }
    }
}
