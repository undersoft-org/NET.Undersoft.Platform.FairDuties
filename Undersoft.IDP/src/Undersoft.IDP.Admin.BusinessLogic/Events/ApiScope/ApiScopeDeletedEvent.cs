using NicmanGroup.AuditLogging.Events;
using Undersoft.IDP.Admin.BusinessLogic.Dtos.Configuration;

namespace Undersoft.IDP.Admin.BusinessLogic.Events.ApiScope
{
    public class ApiScopeDeletedEvent : AuditEvent
    {
        public ApiScopeDto ApiScope { get; set; }

        public ApiScopeDeletedEvent(ApiScopeDto apiScope)
        {
            ApiScope = apiScope;
        }
    }
}