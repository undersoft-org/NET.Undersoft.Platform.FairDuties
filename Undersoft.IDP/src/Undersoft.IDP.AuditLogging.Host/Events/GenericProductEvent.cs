using NicmanGroup.AuditLogging.Events;
using NicmanGroup.AuditLogging.Host.Dtos;

namespace NicmanGroup.AuditLogging.Host.Events
{
    public class GenericProductEvent<T1, T2, T3> : AuditEvent
    {
        public ProductDto Product { get; set; }
    }
}
