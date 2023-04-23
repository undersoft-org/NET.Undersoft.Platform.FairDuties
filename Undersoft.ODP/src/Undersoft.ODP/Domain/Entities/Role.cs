using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using RadicalR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Role : Entity
    {
        public string Name { get; set; }

        public RoleType Type { get; set; }

        public long? UserId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Member User { get; set; }
    }
}