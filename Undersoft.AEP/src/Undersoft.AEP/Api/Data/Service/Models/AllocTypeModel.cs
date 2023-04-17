using UltimatR;

namespace Undersoft.AEP
{
    public class AllocTypeModel : AllocType, IAllocType
    {
        public IEnumerable<ILink> RelatedTo { get; }

        public IEnumerable<ILink> OptionalTo { get; }

        public IEnumerable<ILink> DependentOn { get; }
    }
}
