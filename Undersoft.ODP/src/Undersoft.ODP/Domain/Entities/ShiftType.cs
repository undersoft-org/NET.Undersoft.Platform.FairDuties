using Microsoft.OData.Client;
using Undersoft.AEP;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using UltimatR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class ShiftType : Entity, IAllocType
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ShiftUnit Unit { get; set; }

        public float Size { get; set; }

        public virtual DboToSets<Attribute> Attributes { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboToSets<ShiftType> DependentBy { get; set; }

        public virtual DboToSets<ShiftType> DependentOn { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboToSets<ShiftType> RelatedFrom { get; set; }

        public virtual DboToSets<ShiftType> RelatedTo { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboToSets<ShiftType> OptionalFrom { get; set; }

        public virtual DboToSets<ShiftType> OptionalTo { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboToSet<Shift> Shifts { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboToSet<ShiftRate> ShiftRates { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboToSets<Organization> Organizations { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboToSets<Team> Teams { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboToSets<User> Users { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboToSet<Plan> Plans { get; set; }

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
