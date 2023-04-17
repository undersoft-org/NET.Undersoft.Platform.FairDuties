using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using UltimatR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class CountryLanguage : Entity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboToSet<Country> Countries { get; set; }
    }
}
