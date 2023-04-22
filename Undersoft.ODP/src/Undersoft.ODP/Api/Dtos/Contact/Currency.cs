using RadicalR;

namespace Undersoft.ODP.Api
{
    public partial class Currency : Dto
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public virtual DtoSet<Country> Countries { get; set; }

        public double Rate { get; set; }
    }
}
