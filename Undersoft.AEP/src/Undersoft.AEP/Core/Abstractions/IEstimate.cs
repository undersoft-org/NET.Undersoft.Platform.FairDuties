using System.Instant.Linking;
using System.Uniques;

namespace Undersoft.AEP.Core
{
    public interface IEstimate : IUniqueObject
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