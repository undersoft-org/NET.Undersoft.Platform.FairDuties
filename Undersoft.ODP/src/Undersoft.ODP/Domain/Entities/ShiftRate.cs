using Microsoft.OData.Client;
using System.Instant;
using System.Instant.Linking;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using UltimatR;
using Undersoft.AEP;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class ShiftRate : Entity, IAllocRate
    {
        public string Name { get; set; }

        public double Checksum { get; set; }

        public double Rank { get; set; }

        public double Quantity { get; set; }

        public double Rate { get; set; }

        public double Value { get; set; }

        public double Total { get; set; }

        public int Weekly { get; set; }

        public int Monthly { get; set; }

        public int Yearly { get; set; }

        public int Weekends { get; set; }

        public int Holidays { get; set; }

        public int OnShifts { get; set; }

        public int OffShifts { get; set; }

        public int FreeShifts { get; set; }

        public int Exchanges { get; set; }

        public bool DependentByAny { get; set; }

        public bool OptionalFromAny { get; set; }

        public long? OrganizationId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Organization Organization { get; set; }

        public long? TeamId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Team Team { get; set; }

        public long? UserId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual User User { get; set; }

        [FigureKey]
        [IgnoreDataMember]
        public long? ShiftTypeId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ShiftType ShiftType { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<ShiftRate> DependentBy { get; set; }

        public virtual EntityOnSets<ShiftRate> DependentOn { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<ShiftRate> OptionalFrom { get; set; }

        public virtual EntityOnSets<ShiftRate> OptionalTo { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IAllocRate.AllocSetId
        {
            get => TeamId ?? default;
            set => TeamId = value;
        }


        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IAllocRate.AssetId
        {
            get => UserId ?? default;
            set => UserId = value;
        }


        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IAllocRate.AllocTypeId => ShiftTypeId ?? default;


        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IEnumerable<ILink> IAllocRate.DependentOn =>
            DependentOn.Select(
                i =>
                    new Link<ShiftRate, ShiftRate>("Dependencies")
                    {
                        SourceId = Id,
                        TargetId = i.Id
                    }
            );

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IEnumerable<ILink> IAllocRate.OptionalTo =>
            OptionalTo.Select(
                i =>
                    new Link<ShiftRate, ShiftRate>("Optionals")
                    {
                        SourceId = Id,
                        TargetId = i.Id
                    }
            );
    }
}
