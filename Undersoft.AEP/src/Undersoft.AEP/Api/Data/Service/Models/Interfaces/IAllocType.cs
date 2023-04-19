using System.Instant.Linking;

namespace Undersoft.AEP
{
    public interface IAllocType : IId
    {
        string Name { get; set; }

        float Size { get; set; }

        IEnumerable<ILink> RelatedTo { get; }

        IEnumerable<ILink> OptionalTo { get; }

        IEnumerable<ILink> DependentOn { get; }
    }
}