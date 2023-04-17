using UltimatR;

namespace Undersoft.AEP
{
    public interface ISlot : IIdentifiable
    {
        float Checksum { get; set; }

        long SequenceId { get; set; }

        long BockId { get; set; }

        long FrameId { get; set; }

        long ClaimId { get; set; }
        IClaim Claim { get; set; }

        long ResourceId { get; set; }
        IResource Resource { get; set; }

        long AllocId { get; set; }
        IAlloc Alloc { get; set; }
    }
}