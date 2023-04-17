using NicmanGroup.AuditLogging.Events;
using Undersoft.IDP.Admin.BusinessLogic.Dtos.Configuration;

namespace Undersoft.IDP.Admin.BusinessLogic.Events.ApiScope
{
    public class ApiScopePropertyAddedEvent : AuditEvent
    {
        public ApiScopePropertyAddedEvent(ApiScopePropertiesDto apiScopeProperty)
        {
            ApiScopeProperty = apiScopeProperty;
        }

        public ApiScopePropertiesDto ApiScopeProperty { get; set; }
    }
}