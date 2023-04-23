using RadicalR;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public partial class Country : Entity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Continent { get; set; }

        public string TimeZone { get; set; }

        public long? CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

        public long? LanguageId { get; set; }
        public virtual Language Language { get; set; }

        public virtual EntitySet<CountryState> States { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntitySet<Address> Addresses { get; set; }
    }
}
