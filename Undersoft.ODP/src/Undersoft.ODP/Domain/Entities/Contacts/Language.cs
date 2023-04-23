using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using RadicalR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Language : Entity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSet<Country> Countries { get; set; }
    }
}
