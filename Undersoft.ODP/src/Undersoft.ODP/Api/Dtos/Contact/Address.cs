using RadicalR;

namespace Undersoft.ODP.Api
{
    public class Address : Dto 
    {
        public long ContactId { get; set; }

        public string CityName { get; set; }

        public string StreetName { get; set; }

        public string BuildingNumber { get; set; }

        public string ApartmentNumber { get; set; }

        public string Postcode { get; set; }

        public string Notices { get; set; }

        public long CountryId { get; set; }
        public Country Country { get; set; }

        public long StateId { get; set; }
        public CountryState State { get; set; }
    }
}
