using RadicalR;
using System.Runtime.Serialization;
using Undersoft.AEP.Raw;

namespace Undersoft.AEP.Api
{
    [DataContract]
    public class UsageSet : Raw.UsageSet
    {
        [DataMember(Order = 19)]
        public virtual Vertex Vertex { get; set; }

        [DataMember(Order = 20)]
        public virtual DtoSet<Link<UsageSet, Source>> SourceLinks { get; set; }

        [DataMember(Order = 21)]
        public virtual DtoSet<Link<UsageSet, Asset>> AssetLinks { get; set; }

        [DataMember(Order = 22)]
        public virtual DtoSet<Estimate> Estimates { get; set; }

        [DataMember(Order = 23)]
        public virtual Setup Setup { get; set; }
    }
}
