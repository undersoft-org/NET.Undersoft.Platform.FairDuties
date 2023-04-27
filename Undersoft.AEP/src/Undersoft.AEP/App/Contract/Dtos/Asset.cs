using System.Runtime.Serialization;
using System.Series;
using Undersoft.AEP.Core;

namespace Undersoft.AEP.Api
{
    [DataContract]
    public class Asset : Raw.Asset, IDto
    {
        [DataMember(Order = 13)]
        public Listing<Link<Asset, Asset>> RelatedTo { get; }

        [DataMember(Order = 14)]
        public Listing<Link<Asset, Asset>> OptionalTo { get; }

        [DataMember(Order = 15)]
        public Listing<Link<Asset, Asset>> DependentOn { get; }
    }
}
