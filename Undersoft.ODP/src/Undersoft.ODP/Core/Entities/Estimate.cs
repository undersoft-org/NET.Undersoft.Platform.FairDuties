using RadicalR;
using System.Instant;
using System.Instant.Linking;
using System.Runtime.Serialization;
using Undersoft.AEP.Core;

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

        public UOM Unit { get; set; }

        public int OnDuties { get; set; }

        public int OffDuties { get; set; }

        public int FreeDuties { get; set; }

        public int Exchanges { get; set; }

        public bool DependentByAny { get; set; }

        public bool OptionalFromAny { get; set; }

        [FigureIdentity]
        public long? UnionId { get; set; }
        public virtual Union Union { get; set; }
        
        [FigureIdentity]
        public long? GroupId { get; set; }
        public virtual Group Group { get; set; }
        
        [FigureIdentity]
        public long? MemberId { get; set; }
        public virtual Member Member { get; set; }

        [FigureIdentity]
        public long? AssetId { get; set; }
        public virtual Asset Asset { get; set; }

        public virtual EntityOnSets<Estimate> DependentBy { get; set; }

        public virtual EntityOnSets<Estimate> DependentOn { get; set; }

        public virtual EntityOnSets<Estimate> OptionalFrom { get; set; }

        public virtual EntityOnSets<Estimate> OptionalTo { get; set; }

        long IEstimate.UsageSetId
        {
            get => GroupId ?? default;
            set => GroupId = value;
        }

        public new long SourceId
        {
            get => MemberId ?? default;
            set => MemberId = value;
        }

        IEnumerable<ILink> IEstimate.DependentOn =>
            DependentOn.Select(
                i =>
                    new Link<Estimate, Estimate>("Dependencies")
                    {
                        SourceId = Id,
                        TargetId = i.Id
                    }
            );

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
