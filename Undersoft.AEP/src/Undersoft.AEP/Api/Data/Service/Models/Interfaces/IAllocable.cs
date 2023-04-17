using UltimatR;

namespace Undersoft.AEP
{
    public interface IAllocable : IIdentifiable
    {
        long UniverseId { get; }

        long AssetId { get; set; }

        long AllocSetId { get; }

        long AllocTypeId { get; set; }

        long AllocRateId { get; set; }

        long SequenceId { get; set; }

        long BlockId { get; set; }

        long FrameId { get; set; }

        long SlotId { get; set; }

        long AllocId { get; set; }

        long ResourceId { get; set; }

        long ClaimId { get; set; }
    }
}