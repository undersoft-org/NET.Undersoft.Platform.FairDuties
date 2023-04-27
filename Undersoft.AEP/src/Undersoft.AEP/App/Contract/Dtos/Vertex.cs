using System.Runtime.Serialization;
using System.Series;

namespace Undersoft.AEP.Api
{
    [DataContract]
    public class Vertex : Raw.Vertex, IDto
    {
        [DataMember(Order = 12)]
        public virtual string Name { get; set; }

        [DataMember(Order = 13)]
        public virtual Listing<UsageSet> UsageSets { get; set; }

        [DataMember(Order = 14)]
        public virtual Listing<Asset> Assets { get; set; }

        [DataMember(Order = 15)]
        public virtual Listing<Source> Sources { get; set; }

        [DataMember(Order = 16)]
        public virtual Setup Setup { get; set; }
    }
}
