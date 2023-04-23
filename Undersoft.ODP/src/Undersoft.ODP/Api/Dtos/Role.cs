using RadicalR;
using Undersoft.ODP.Domain;

namespace Undersoft.ODP.Api
{
    public class Role : Dto
    {
        public long? UserId { get; set; }

        public string Name { get; set; }

        public RoleType Type { get; set; }
    }
}