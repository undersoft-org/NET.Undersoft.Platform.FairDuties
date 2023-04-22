using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using RadicalR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class ShiftRequest : Entity
    {
        public string Reason { get; set; }

        public string Description { get; set; }

        public ShiftRequestType Type { get; set; }

        public ShiftRequestStatus Status { get; set; }

        public long? TeamId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Team Team { get; set; }

        public long? UserId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual User User { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Shift> Shifts { get; set; }
    }
}
