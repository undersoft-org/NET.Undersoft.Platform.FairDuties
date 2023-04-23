using RadicalR;

namespace Undersoft.ODP.Api
{
    public partial class Language :  Dto
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public DtoSet<Country> Countries { get; set; } = new();
    }
}
