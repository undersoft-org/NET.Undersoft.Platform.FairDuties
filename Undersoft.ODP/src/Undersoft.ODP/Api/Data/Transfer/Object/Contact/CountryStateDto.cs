using UltimatR;

namespace Undersoft.ODP.Api
{
    public class CountryStateDto : Dto
    {
        public long CountryId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string TimeZone { get; set; }
    }
}
