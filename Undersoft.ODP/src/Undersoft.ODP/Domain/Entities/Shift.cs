using Microsoft.OData.Client;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using RadicalR;
using Undersoft.AEP;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Shift : Entity, IAllocable
    {
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

        public long? ShiftTypeId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ShiftType ShiftType { get; set; }

        public long? ScheduleId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Schedule Schedule { get; set; }

        public long? ShiftRateId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public WorkMode WorkMode { get; set; }

        public ShiftStatus Status { get; set; }

        public bool HasRequests { get; set; }

        public bool IsRequested { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<ShiftRequest> Requests { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Schedule> ScheduleViews { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IAllocable.UniverseId => OrganizationId ?? default;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IAllocable.AssetId
        {
            get => UserId ?? default;
            set => UserId = value;
        }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IAllocable.AllocSetId => TeamId ?? default;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IAllocable.AllocTypeId
        {
            get => ShiftTypeId ?? default;
            set => ShiftTypeId = value;
        }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IAllocable.AllocRateId
        {
            get => ShiftRateId ?? default;
            set => ShiftRateId = value;
        }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IAllocable.SequenceId
        {
            get => ScheduleId ?? default;
            set => ScheduleId = value;
        }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IAllocable.ResourceId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IAllocable.ClaimId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IAllocable.SlotId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IAllocable.FrameId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IAllocable.BlockId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IAllocable.AllocId { get; set; }
    }
}
