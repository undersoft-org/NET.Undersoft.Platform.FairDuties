using UltimatR;

namespace Undersoft.ODP.Api
{
    public partial class CountryLanguageDto :  Dto
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public DtoSet<CountryDto> Countries { get; set; } = new();
    }
}
