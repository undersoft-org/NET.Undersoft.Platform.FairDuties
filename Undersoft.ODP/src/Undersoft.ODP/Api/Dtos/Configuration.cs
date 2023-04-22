using Undersoft.ODP.Domain;
using RadicalR;

namespace Undersoft.ODP.Api
{
    public class Configuration : Dto
    {
        public long? OrganizationId { get; set; }

        public long? TeamId { get; set; }

        public long? UserId { get; set; }

        public virtual DtoSet<Setting> Settings { get; set; }
    }
}