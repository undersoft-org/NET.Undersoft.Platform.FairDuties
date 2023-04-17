using NicmanGroup.AuditLogging.Events;
using Undersoft.IDP.Admin.BusinessLogic.Dtos.Configuration;

namespace Undersoft.IDP.Admin.BusinessLogic.Events.ApiResource
{
    public class ApiResourcePropertyDeletedEvent : AuditEvent
    {
        public ApiResourcePropertyDeletedEvent(ApiResourcePropertiesDto apiResourceProperty)
        {
            ApiResourceProperty = apiResourceProperty;
        }

        public ApiResourcePropertiesDto ApiResourceProperty { get; set; }
    }
}