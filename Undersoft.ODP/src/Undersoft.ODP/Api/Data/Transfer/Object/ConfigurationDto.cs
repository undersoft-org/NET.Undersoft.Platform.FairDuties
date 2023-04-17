using Undersoft.ODP.Domain;
using UltimatR;

namespace Undersoft.ODP.Api
{
    public class ConfigurationDto : Dto
    {
        public long? OrganizationId { get; set; }

        public long? TeamId { get; set; }

        public long? UserId { get; set; }

        public virtual DtoSet<SettingDto> Settings { get; set; }
    }
}