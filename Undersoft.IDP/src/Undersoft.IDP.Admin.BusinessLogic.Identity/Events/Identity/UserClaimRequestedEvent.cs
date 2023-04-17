using NicmanGroup.AuditLogging.Events;

namespace Undersoft.IDP.Admin.BusinessLogic.Identity.Events.Identity
{
    public class UserClaimRequestedEvent<TUserClaimsDto> : AuditEvent
    {
        public TUserClaimsDto UserClaims { get; set; }

        public UserClaimRequestedEvent(TUserClaimsDto userClaims)
        {
            UserClaims = userClaims;
        }
    }
}