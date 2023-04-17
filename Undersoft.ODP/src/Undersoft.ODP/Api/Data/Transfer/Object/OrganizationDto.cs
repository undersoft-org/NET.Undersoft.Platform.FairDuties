using UltimatR;

namespace Undersoft.ODP.Api
{

    public class OrganizationDto : Dto
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public string Notices { get; set; }

        public virtual DtoSet<AttributeDto> Attributes { get; set; }

        public long? ConfigurationId { get; set; }
        public virtual ConfigurationDto Configuration { get; set; }
    }
}