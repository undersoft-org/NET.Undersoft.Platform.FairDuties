using NicmanGroup.AuditLogging.Events;
using Undersoft.IDP.Admin.BusinessLogic.Dtos.Grant;

namespace Undersoft.IDP.Admin.BusinessLogic.Events.PersistedGrant
{
    public class PersistedGrantRequestedEvent : AuditEvent
    {
        public PersistedGrantDto PersistedGrant { get; set; }

        public PersistedGrantRequestedEvent(PersistedGrantDto persistedGrant)
        {
            PersistedGrant = persistedGrant;
        }
    }
}