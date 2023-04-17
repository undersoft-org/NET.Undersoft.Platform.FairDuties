using UltimatR;

namespace Undersoft.ODP.Api
{

    public class BasicOrganizationDto : Dto
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public long? ConfigurationId { get; set; }
    }
}