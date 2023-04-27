using System.Runtime.Serialization;
using System.Series;
using Undersoft.AEP.Core;

namespace Undersoft.AEP.Api
{
    [DataContract]
    public class Estimate : Raw.Estimate, IDto
    {
        [DataMember(Order = 22)]
        public Listing<Link<Estimate, Estimate>> DependentOn { get; set; }

        [DataMember(Order = 23)]
        public Listing<Link<Estimate, Estimate>> OptionalTo { get; set; }
    }
}
