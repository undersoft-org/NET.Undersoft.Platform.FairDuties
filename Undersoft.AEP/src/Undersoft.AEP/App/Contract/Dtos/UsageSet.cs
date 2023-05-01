using System.Instant.Linking;
using System.Runtime.Serialization;
using System.Series;
using Undersoft.AEP.Core;

namespace Undersoft.AEP.Api
{
    [DataContract]
    public class UsageSet : Raw.UsageSet, IDto
    {
        [DataMember(Order = 19)]
        public virtual Vertex Vertex { get; set; }

        [DataMember(Order = 20)]
        public virtual Listing<Link<UsageSet, Source>> SourceLinks { get; set; }

        [DataMember(Order = 21)]
        public virtual Listing<Link<UsageSet, Asset>> AssetLinks { get; set; }

        [DataMember(Order = 22)]
        public virtual Listing<Estimate> Estimates { get; set; }

        [DataMember(Order = 23)]
        public virtual Setup Setup { get; set; }
    }
}
