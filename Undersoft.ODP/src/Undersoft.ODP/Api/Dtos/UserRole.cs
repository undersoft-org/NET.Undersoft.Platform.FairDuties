using UltimatR;
using Undersoft.ODP.Domain;

namespace Undersoft.ODP.Api
{
    public class UserRole : Dto
    {
        public long? UserId { get; set; }

        public string Name { get; set; }

        public RoleType Type { get; set; }
    }
}