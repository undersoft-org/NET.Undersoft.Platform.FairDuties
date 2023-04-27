using RadicalR;

namespace Undersoft.ODP.Api
{

    public class Union : Dto
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public string Notices { get; set; }

        public virtual DtoSet<Property> Properties { get; set; }

        public long? SetupId { get; set; }
        public virtual Setup Setup { get; set; }
    }
}