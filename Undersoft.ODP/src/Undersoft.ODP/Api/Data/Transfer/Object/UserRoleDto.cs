using Undersoft.ODP.Domain;
using UltimatR;

namespace Undersoft.ODP.Api
{
    public class UserRoleDto : Dto
    {
        public long? UserId { get; set; }

        public string Name { get; set; }
        
        public RoleType Type { get; set; }
    }
}