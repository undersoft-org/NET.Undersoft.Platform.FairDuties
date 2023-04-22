using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using RadicalR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class CountryState : Entity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string TimeZone { get; set; }

        public long? CountryId { get; set; }
        public virtual Country Country { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSet<Address> Addresses { get; set; }
    }
}
