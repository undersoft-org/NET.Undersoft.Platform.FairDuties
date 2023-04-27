using System.Uniques;

namespace Undersoft.AEP.Core
{
    public class Socket<TType, TEstimate, TObject, TItem> : Socket
        where TItem : IUsability
        where TType : IAsset
        where TEstimate : IEstimate
        where TObject : ISource
    {
        public Socket() { }

        public new Liability<TType, TEstimate> Liability
        {
            get => (Liability<TType, TEstimate>)base.Liability;
            set => base.Liability = value;
        }

        public new Resource<TType, TEstimate, TObject> Resource
        {
            get => (Resource<TType, TEstimate, TObject>)base.Resource;
            set => base.Resource = value;
        }

        public new Usage<TItem> Usage
        {
            get => (Usage<TItem>)base.Usage;
            set => base.Usage = value;
        }
    }

    public class Socket : UniqueObject, ISocket
    {
        public Socket() { }

        public float Checksum { get; set; }

        public long LiabilityId { get; set; }
        public virtual ILiability Liability { get; set; }

        public long ResourceId { get; set; }
        public virtual IResource Resource { get; set; }

        public long UsageId { get; set; }
        public virtual IUsage Usage { get; set; }

        public long VectorId { get; set; }

        public long SectorId { get; set; }

        public long BlockId { get; set; }
    }
}
