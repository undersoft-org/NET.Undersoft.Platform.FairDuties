using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using RadicalR;

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
        public virtual CountryLanguage Language { get; set; }

        public virtual EntityOnSet<CountryState> States { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSet<Address> Addresses { get; set; }
    }
}
