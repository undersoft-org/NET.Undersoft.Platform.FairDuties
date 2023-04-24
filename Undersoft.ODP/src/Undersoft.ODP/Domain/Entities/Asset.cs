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

        public double Value { get; set; }

        public virtual EntityOnSets<Property> Properties { get; set; }

        public virtual EntityOnSets<Asset> DependentBy { get; set; }

        public virtual EntityOnSets<Asset> DependentOn { get; set; }

        public virtual EntityOnSets<Asset> RelatedFrom { get; set; }

        public virtual EntityOnSets<Asset> RelatedTo { get; set; }

        public virtual EntityOnSets<Asset> OptionalFrom { get; set; }
         
        public virtual EntityOnSets<Asset> OptionalTo { get; set; }

        public virtual EntityOnSet<Duty> Duties { get; set; }

        public virtual EntityOnSet<Estimate> Rates { get; set; }

        public virtual EntityOnSets<Union> Unions { get; set; }

        public virtual EntityOnSets<Group> Groups { get; set; }

        public virtual EntityOnSets<Member> Members { get; set; }

        public virtual EntityOnSet<Vertex> Vertices { get; set; }

        IEnumerable<ILink> IAsset.DependentOn => DependentOn.Select(i => new Link<Asset, Asset>("Dependencies") { SourceId = Id, TargetId = i.Id });

        IEnumerable<ILink> IAsset.RelatedTo => RelatedTo.Select(i => new Link<Asset, Asset>("Relations") { SourceId = Id, TargetId = i.Id });

        IEnumerable<ILink> IAsset.OptionalTo => OptionalTo.Select(i => new Link<Asset, Asset>("Optionals") { SourceId = Id, TargetId = i.Id });
    }

    public enum DutyUnit
    {
        Piece = 1,
        Kilogram = 1000, 
        Centimeter = 10,
        Meter = 100 * 10,
        MB = 1024 * 1024,
        MFLOPS = 1024 * 1024 * 4, 
        Hour = 60,
        Day = 1440,
        TwelveHours = 720,
        EightHours = 480,
    }
}
