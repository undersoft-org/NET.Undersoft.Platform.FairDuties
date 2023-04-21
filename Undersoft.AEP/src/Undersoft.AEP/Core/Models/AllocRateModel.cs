using System.Instant.Linking;

namespace Undersoft.AEP
{
    public class AllocRateModel : AllocRate, IAllocRate
    {
        public IEnumerable<ILink> DependentOn { get; }

        public IEnumerable<ILink> OptionalTo { get; }
    }
}
