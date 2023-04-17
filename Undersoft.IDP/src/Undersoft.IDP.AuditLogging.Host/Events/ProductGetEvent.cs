using NicmanGroup.AuditLogging.Events;
using NicmanGroup.AuditLogging.Host.Dtos;

namespace NicmanGroup.AuditLogging.Host.Events
{
    public class ProductGetEvent : AuditEvent
    {
        public ProductDto Product { get; set; }
    }
}
