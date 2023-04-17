using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using UltimatR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public partial class Currency : Entity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboToSet<Country> Countries { get; set; }

        public double Rate { get; set; }
    }
}
