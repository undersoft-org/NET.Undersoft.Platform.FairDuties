using System.Instant.Linking;
using UltimatR;

namespace Undersoft.AEP
{
    public interface IAllocRate : IIdentifiable
    {
        double Rank { get; set; }

        double Checksum { get; set; }

        double Quantity { get; set; }

        double Rate { get; set; }

        double Value { get; set; }

        double Total { get; set; }

        bool DependentByAny { get; set; }

        bool OptionalFromAny { get; set; }

        long AllocSetId { get; set; }

        long AssetId { get; set; }

        long AllocTypeId { get; }

        IEnumerable<ILink> DependentOn { get; }

        IEnumerable<ILink> OptionalTo { get; }
    }
}