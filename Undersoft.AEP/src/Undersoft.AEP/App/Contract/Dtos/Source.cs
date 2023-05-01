using System.Instant.Linking;
using System.Runtime.Serialization;
using System.Series;

namespace Undersoft.AEP.Api
{
    [DataContract]
    public class Source : Raw.Source, IDto
    {
        [DataMember(Order = 12)]
        public virtual Listing<Estimate> Estimates { get; set; }

        [DataMember(Order = 13)]
        public virtual Listing<Link<Asset, Asset>> AssetLinks { get; set; }

        [DataMember(Order = 14)]
        public virtual Setup Setup { get; set; }
    }
}
