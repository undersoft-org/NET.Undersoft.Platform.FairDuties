using System.Runtime.Serialization;
using RadicalR;

namespace Undersoft.AEP
{
    [DataContract]
    public class AllocTypeDto : AllocType
    {
        [DataMember(Order = 13)]
        public DtoSet<Link<AllocType, AllocTypeDto>> RelatedTo { get; }

        [DataMember(Order = 14)]
        public DtoSet<Link<AllocType, AllocTypeDto>> OptionalTo { get; }

        [DataMember(Order = 15)]
        public DtoSet<Link<AllocType, AllocTypeDto>> DependentOn { get; }
    }
}
