using RadicalR;
using System.Runtime.Serialization;
using Undersoft.AEP.Raw;

namespace Undersoft.AEP.Api
{
    [DataContract]
    public class Estimate : Raw.Estimate
    {
        [DataMember(Order = 22)]
        public DtoSet<Link<Estimate, Estimate>> DependentOn { get; set; }

        [DataMember(Order = 23)]
        public DtoSet<Link<Estimate, Estimate>> OptionalTo { get; set; }
    }
}
