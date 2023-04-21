using UltimatR;

namespace Undersoft.AEP
{
    public class SlotModel<TType, TRate, TObject, TItem> : SlotModel
        where TItem : IAllocable
        where TType : IAllocType
        where TRate : IAllocRate
        where TObject : IAsset
    {
        public SlotModel() { }

        public new ClaimModel<TType, TRate> Claim
        {
            get => (ClaimModel<TType, TRate>)base.Claim;
            set => base.Claim = value;
        }

        public new ResourceModel<TType, TRate, TObject> Resource
        {
            get => (ResourceModel<TType, TRate, TObject>)base.Resource;
            set => base.Resource = value;
        }

        public new AllocModel<TItem> Alloc
        {
            get => (AllocModel<TItem>)base.Alloc;
            set => base.Alloc = value;
        }
    }

    public class SlotModel : Identifiable, ISlot
    {
        public SlotModel() { }

        public float Checksum { get; set; }

        public long ClaimId { get; set; }
        public virtual IClaim Claim { get; set; }

        public long ResourceId { get; set; }
        public virtual IResource Resource { get; set; }

        public long AllocId { get; set; }
        public virtual IAlloc Alloc { get; set; }

        public long SequenceId { get; set; }

        public long BockId { get; set; }

        public long FrameId { get; set; }
    }
}
