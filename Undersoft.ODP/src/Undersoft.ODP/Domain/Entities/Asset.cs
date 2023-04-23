using Microsoft.OData.Client;
using RadicalR;
using System.Instant.Linking;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Undersoft.AEP.Core;
using Undersoft.AEP.Raw;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Asset : Entity, IAsset
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DutyUnit Unit { get; set; }

        public float Size { get; set; }

        public virtual EntityOnSets<Property> Properties { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Asset> DependentBy { get; set; }

        public virtual EntityOnSets<Asset> DependentOn { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Asset> RelatedFrom { get; set; }

        public virtual EntityOnSets<Asset> RelatedTo { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Asset> OptionalFrom { get; set; }

        public virtual EntityOnSets<Asset> OptionalTo { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSet<Duty> Duties { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSet<Estimate> Rates { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Union> Unions { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Group> Groups { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Member> Members { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSet<Vertex> Plans { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IEnumerable<ILink> IAsset.DependentOn => DependentOn.Select(i => new Link<Asset, Asset>("Dependencies") { SourceId = Id, TargetId = i.Id });

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IEnumerable<ILink> IAsset.RelatedTo => RelatedTo.Select(i => new Link<Asset, Asset>("Relations") { SourceId = Id, TargetId = i.Id });

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IEnumerable<ILink> IAsset.OptionalTo => OptionalTo.Select(i => new Link<Asset, Asset>("Optionals") { SourceId = Id, TargetId = i.Id });
    }

    public enum DutyUnit
    {
        Hour = 1,
        Day = 24,
        TwelveHours = 12,
        EightHours = 8,
    }
}
