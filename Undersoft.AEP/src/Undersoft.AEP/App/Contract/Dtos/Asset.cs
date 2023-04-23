using RadicalR;
using System.Runtime.Serialization;
using Undersoft.AEP.Raw;

namespace Undersoft.AEP.Api
{
    [DataContract]
    public class Asset : Raw.Asset
    {
        [DataMember(Order = 13)]
        public DtoSet<Link<Asset, Asset>> RelatedTo { get; }

        [DataMember(Order = 14)]
        public DtoSet<Link<Asset, Asset>> OptionalTo { get; }

        [DataMember(Order = 15)]
        public DtoSet<Link<Asset, Asset>> DependentOn { get; }
    }
}
