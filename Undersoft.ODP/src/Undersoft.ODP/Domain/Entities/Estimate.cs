using Microsoft.OData.Client;
using RadicalR;
using System.Instant;
using System.Instant.Linking;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Undersoft.AEP.Core;
using Undersoft.AEP.Raw;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Estimate : Entity, IEstimate
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

        public int OnDuties { get; set; }

        public int OffDuties { get; set; }

        public int FreeDuties { get; set; }

        public int Exchanges { get; set; }

        public bool DependentByAny { get; set; }

        public bool OptionalFromAny { get; set; }

        public long? UnionId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Union Union { get; set; }

        public long? GroupId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Group Group { get; set; }

        public long? MemberId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Member Member { get; set; }

        [FigureKey]
        [IgnoreDataMember]
        public long? AssetId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Asset Asset { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Estimate> DependentBy { get; set; }

        public virtual EntityOnSets<Estimate> DependentOn { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Estimate> OptionalFrom { get; set; }

        public virtual EntityOnSets<Estimate> OptionalTo { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IEstimate.UsageSetId
        {
            get => GroupId ?? default;
            set => GroupId = value;
        }


        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        public new long SourceId
        {
            get => MemberId ?? default;
            set => MemberId = value;
        }


        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IEnumerable<ILink> IEstimate.DependentOn =>
            DependentOn.Select(
                i =>
                    new Link<Estimate, Estimate>("Dependencies")
                    {
                        SourceId = Id,
                        TargetId = i.Id
                    }
            );

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IEnumerable<ILink> IEstimate.OptionalTo =>
            OptionalTo.Select(
                i =>
                    new Link<Estimate, Estimate>("Optionals")
                    {
                        SourceId = Id,
                        TargetId = i.Id
                    }
            );

        long IEstimate.AssetId => AssetId ?? default;
    }
}
