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
        public virtual Union Union { get; set; }

        public long? GroupId { get; set; }
        public virtual Group Group { get; set; }

        public long? MemberId { get; set; }
        public virtual Member Member { get; set; }

        public long? AssetId { get; set; }
        public virtual Asset Asset { get; set; }

        public long? VectorId { get; set; }
        public virtual Vector Vector { get; set; }

        public long? EstimateId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DutyMode Mode { get; set; }

        public DutyStatus Status { get; set; }

        public bool HasRequests { get; set; }

        public bool IsRequested { get; set; }

        public virtual EntityOnSets<Request> Requests { get; set; }

        public virtual EntityOnSets<Vector> VectorViews { get; set; }

        long IUsability.VertexId => UnionId ?? default;

        long IUsability.UsageSetId => GroupId ?? default;

        long IUsability.AssetId
        {
            get => AssetId ?? default;
            set => AssetId = value;
        }

        long IUsability.EstimateId
        {
            get => EstimateId ?? default;
            set => EstimateId = value;
        }

        long IUsability.VectorId
        {
            get => VectorId ?? default;
            set => VectorId = value;
        }

        long IUsability.ResourceId { get; set; }

        long IUsability.SocketId { get; set; }

        long IUsability.SectorId { get; set; }

        long IUsability.BlockId { get; set; }

        long IUsability.UsageId { get; set; }
    }
}
