using System.Instant.Linking;

namespace Undersoft.AEP.Core
{
    public interface IAsset : IId
    {
        string Name { get; set; }

        double Value { get; set; }

        IEnumerable<ILink> RelatedTo { get; }

        IEnumerable<ILink> OptionalTo { get; }

        IEnumerable<ILink> DependentOn { get; }
    }
}