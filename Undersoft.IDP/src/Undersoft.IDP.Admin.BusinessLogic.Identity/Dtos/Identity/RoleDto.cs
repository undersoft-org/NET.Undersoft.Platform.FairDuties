using System.ComponentModel.DataAnnotations;
using Undersoft.IDP.Admin.BusinessLogic.Identity.Dtos.Identity.Base;
using Undersoft.IDP.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace Undersoft.IDP.Admin.BusinessLogic.Identity.Dtos.Identity
{
    public class RoleDto<TKey> : BaseRoleDto<TKey>, IRoleDto
    {      
        [Required]
        public string Name { get; set; }
    }
}