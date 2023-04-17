using System.ComponentModel.DataAnnotations;
using Undersoft.IDP.Admin.BusinessLogic.Identity.Dtos.Identity.Base;
using Undersoft.IDP.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace Undersoft.IDP.Admin.BusinessLogic.Identity.Dtos.Identity
{
    public class UserClaimDto<TKey> : BaseUserClaimDto<TKey>, IUserClaimDto
    {
        [Required]
        public string ClaimType { get; set; }

        [Required]
        public string ClaimValue { get; set; }
    }
}