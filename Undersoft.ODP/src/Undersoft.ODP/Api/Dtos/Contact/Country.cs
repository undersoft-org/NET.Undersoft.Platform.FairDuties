using UltimatR;

namespace Undersoft.ODP.Api
{
    public partial class Country : Dto
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Continent { get; set; }

        public string TimeZone { get; set; }

        public long LanguageId { get; set; }
        public CountryLanguage Language { get; set; }

        public DtoSet<CountryState> States { get; set; } = new();
    }
}
