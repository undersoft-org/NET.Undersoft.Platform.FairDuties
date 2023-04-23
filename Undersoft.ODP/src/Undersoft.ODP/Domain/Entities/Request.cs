using RadicalR;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Request : Entity
    {
        public string Reason { get; set; }

        public string Description { get; set; }

        public RequestType Type { get; set; }

        public RequestStatus Status { get; set; }

        public long? GroupId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Group Group { get; set; }

        public long? UserId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Member User { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Duty> Frames { get; set; }
    }
}
