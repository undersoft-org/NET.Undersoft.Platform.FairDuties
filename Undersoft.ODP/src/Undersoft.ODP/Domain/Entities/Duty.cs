using Microsoft.OData.Client;
using RadicalR;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Undersoft.AEP.Core;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Duty : Entity, IUsability
    {
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

        public long? AssetId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Asset Asset { get; set; }

        public long? VectorId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Vector Vector { get; set; }

        public long? EstimateId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DutyMode Mode { get; set; }

        public DutyStatus Status { get; set; }

        public bool HasRequests { get; set; }

        public bool IsRequested { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Request> Requests { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Vector> VectorViews { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IUsability.VertexId => UnionId ?? default;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IUsability.UsageSetId => GroupId ?? default;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IUsability.AssetId
        {
            get => AssetId ?? default;
            set => AssetId = value;
        }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IUsability.EstimateId
        {
            get => EstimateId ?? default;
            set => EstimateId = value;
        }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IUsability.VectorId
        {
            get => VectorId ?? default;
            set => VectorId = value;
        }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IUsability.ResourceId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IUsability.SocketId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IUsability.SectorId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IUsability.UsageId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IUsability.BlockId { get; set; }
    }
}
