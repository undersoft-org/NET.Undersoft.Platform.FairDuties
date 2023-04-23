using RadicalR;
using System.Runtime.Serialization;
using Undersoft.AEP.Raw;

namespace Undersoft.AEP.Api
{
    [DataContract]
    public class Source : Raw.Source
    {
        [DataMember(Order = 12)]
        public virtual DtoSet<Estimate> Estimates { get; set; }

        [DataMember(Order = 13)]
        public virtual DtoSet<Link<Asset, Asset>> AssetLinks { get; set; }

        [DataMember(Order = 14)]
        public virtual Setup Setup { get; set; }
    }
}
