using System.Instant.Linking;

namespace Undersoft.AEP.Core
{
    public class Estimate : Raw.Estimate, IEstimate
    {
        public IEnumerable<ILink> DependentOn { get; }

        public IEnumerable<ILink> OptionalTo { get; }
    }
}
