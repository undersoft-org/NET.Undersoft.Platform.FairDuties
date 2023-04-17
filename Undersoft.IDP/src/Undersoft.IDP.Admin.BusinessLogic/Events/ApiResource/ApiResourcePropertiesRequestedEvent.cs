using NicmanGroup.AuditLogging.Events;
using Undersoft.IDP.Admin.BusinessLogic.Dtos.Configuration;

namespace Undersoft.IDP.Admin.BusinessLogic.Events.ApiResource
{
    public class ApiResourcePropertiesRequestedEvent : AuditEvent
    {
        public ApiResourcePropertiesRequestedEvent(int apiResourceId, ApiResourcePropertiesDto apiResourceProperties)
        {
            ApiResourceId = apiResourceId;
            ApiResourceProperties = apiResourceProperties;
        }

        public int ApiResourceId { get; set; }
        public ApiResourcePropertiesDto ApiResourceProperties { get; }
    }
}