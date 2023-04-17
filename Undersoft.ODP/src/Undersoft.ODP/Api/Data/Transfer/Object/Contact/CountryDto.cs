using UltimatR;

namespace Undersoft.ODP.Api
{
    public partial class CountryDto : Dto
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Continent { get; set; }

        public string TimeZone { get; set; }

        public long LanguageId { get; set; }
        public CountryLanguageDto Language { get; set; }

        public DtoSet<CountryStateDto> States { get; set; } = new();
    }
}
