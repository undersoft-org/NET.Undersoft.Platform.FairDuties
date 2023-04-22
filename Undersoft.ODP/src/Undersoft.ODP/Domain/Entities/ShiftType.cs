using Microsoft.OData.Client;
using System.Instant.Linking;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using RadicalR;
using Undersoft.AEP;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class ShiftType : Entity, IAllocType
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ShiftUnit Unit { get; set; }

        public float Size { get; set; }

        public virtual EntityOnSets<Attribute> Attributes { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<ShiftType> DependentBy { get; set; }

        public virtual EntityOnSets<ShiftType> DependentOn { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<ShiftType> RelatedFrom { get; set; }

        public virtual EntityOnSets<ShiftType> RelatedTo { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<ShiftType> OptionalFrom { get; set; }

        public virtual EntityOnSets<ShiftType> OptionalTo { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSet<Shift> Shifts { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSet<ShiftRate> ShiftRates { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Organization> Organizations { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Team> Teams { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<User> Users { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSet<Plan> Plans { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IEnumerable<ILink> IAllocType.DependentOn => DependentOn.Select(i => new Link<ShiftType, ShiftType>("Dependencies") { SourceId = Id, TargetId = i.Id });

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IEnumerable<ILink> IAllocType.RelatedTo => RelatedTo.Select(i => new Link<ShiftType, ShiftType>("Relations") { SourceId = Id, TargetId = i.Id });

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IEnumerable<ILink> IAllocType.OptionalTo => OptionalTo.Select(i => new Link<ShiftType, ShiftType>("Optionals") { SourceId = Id, TargetId = i.Id });
    }

    public enum ShiftUnit
    {
        Hour = 1,
        Day = 24,
        TwelveHours = 12,
        EightHours = 8,
    }
}
