using UltimatR;

namespace Undersoft.ODP.Api
{

    public class Organization : Dto
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public string Notices { get; set; }

        public virtual DtoSet<Attribute> Attributes { get; set; }

        public long? ConfigurationId { get; set; }
        public virtual Configuration Configuration { get; set; }
    }
}