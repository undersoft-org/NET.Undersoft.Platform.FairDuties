using NicmanGroup.AuditLogging.Events;

namespace Undersoft.IDP.Admin.BusinessLogic.Identity.Events.Identity
{
    public class RoleClaimsSavedEvent<TRoleClaimsDto> : AuditEvent
    {
        public TRoleClaimsDto Claims { get; set; }

        public RoleClaimsSavedEvent(TRoleClaimsDto claims)
        {
            Claims = claims;
        }
    }
}