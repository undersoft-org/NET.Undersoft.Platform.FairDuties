using System.Runtime.Serialization;
using RadicalR;

namespace Undersoft.AEP
{
    [DataContract]
    public class AllocRateDto : AllocRate
    {
        [DataMember(Order = 22)]
        public DtoSet<Link<AllocRate, AllocRateDto>> DependentOn { get; set; }

        [DataMember(Order = 23)]
        public DtoSet<Link<AllocRate, AllocRateDto>> OptionalTo { get; set; }
    }
}
