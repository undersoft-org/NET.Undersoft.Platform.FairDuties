using UltimatR;

namespace Undersoft.ODP.Api
{
    public class AddressDto : Dto 
    {
        public long ContactId { get; set; }

        public string CityName { get; set; }

        public string StreetName { get; set; }

        public string BuildingNumber { get; set; }

        public string ApartmentNumber { get; set; }

        public string Postcode { get; set; }

        public string Notices { get; set; }

        public long CountryId { get; set; }
        public CountryDto Country { get; set; }

        public long StateId { get; set; }
        public CountryStateDto State { get; set; }
    }
}
