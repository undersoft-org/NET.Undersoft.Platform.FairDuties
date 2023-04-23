using RadicalR;

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

        public new Usage<TItem> Exploit
        {
            get => (Usage<TItem>)base.Exploit;
            set => base.Exploit = value;
        }
    }

    public class Socket : Identifiable, ISocket
    {
        public Socket() { }

        public float Checksum { get; set; }

        public long LiabilityId { get; set; }
        public virtual ILiability Liability { get; set; }

        public long ResourceId { get; set; }
        public virtual IResource Resource { get; set; }

        public long ExploitId { get; set; }
        public virtual IUsage Exploit { get; set; }

        public long VectorId { get; set; }

        public long BockId { get; set; }

        public long FrameId { get; set; }
    }
}
