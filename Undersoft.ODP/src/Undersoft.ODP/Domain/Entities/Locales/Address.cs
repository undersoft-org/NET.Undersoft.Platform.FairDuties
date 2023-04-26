using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using RadicalR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Address : Entity
    {
        public string CityName { get; set; }

        public string StreetName { get; set; }

        public string BuildingNumber { get; set; }

        public string ApartmentNumber { get; set; }

        public string Postcode { get; set; }

        public string Notices { get; set; }

        public AddressType Type { get; set; }

        public long? CountryId { get; set; }
        public virtual Country Country { get; set; }

        public long? StateId { get; set; }
        public virtual CountryState State { get; set; }

        public long? ContactId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Locale Contact { get; set; }
    }
}
