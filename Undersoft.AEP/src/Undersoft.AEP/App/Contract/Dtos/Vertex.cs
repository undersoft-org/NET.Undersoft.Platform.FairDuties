using RadicalR;
using System.Runtime.Serialization;

namespace Undersoft.AEP.Api
{
    [DataContract]
    public class Vertex : Raw.Vertex
    {
        [DataMember(Order = 12)]
        public virtual string Name { get; set; }

        [DataMember(Order = 13)]
        public virtual DtoSet<UsageSet> UsageSets { get; set; }

        [DataMember(Order = 14)]
        public virtual DtoSet<Asset> Assets { get; set; }

        [DataMember(Order = 15)]
        public virtual DtoSet<Source> Sources { get; set; }

        [DataMember(Order = 16)]
        public virtual Setup Setup { get; set; }
    }
}
