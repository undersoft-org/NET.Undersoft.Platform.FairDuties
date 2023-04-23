using RadicalR;
using System.Instant.Linking;

namespace Undersoft.AEP.Core
{
    public interface IEstimate : IIdentifiable
    {
        double Rank { get; set; }

        double Checksum { get; set; }

        double Quantity { get; set; }

        double Rate { get; set; }

        double Value { get; set; }

        double Total { get; set; }

        bool DependentByAny { get; set; }

        bool OptionalFromAny { get; set; }

        long UsageSetId { get; set; }

        long AssetId { get; }

        IEnumerable<ILink> DependentOn { get; }

        IEnumerable<ILink> OptionalTo { get; }
    }
}