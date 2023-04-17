using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using UltimatR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class UserRole : Entity
    {
        public string Name { get; set; }

        public RoleType Type { get; set; }

        public long? UserId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual User User { get; set; }
    }
}