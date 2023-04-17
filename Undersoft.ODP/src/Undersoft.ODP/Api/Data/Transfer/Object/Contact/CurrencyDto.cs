using UltimatR;

namespace Undersoft.ODP.Api
{
    public partial class CurrencyDto : Dto
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public virtual DtoSet<CountryDto> Countries { get; set; }

        public double Rate { get; set; }
    }
}
