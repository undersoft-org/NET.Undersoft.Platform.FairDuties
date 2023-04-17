using Microsoft.Extensions.DependencyInjection;

namespace NicmanGroup.AuditLogging.Extensions
{
    public interface IAuditLoggingBuilder
    {
        IServiceCollection Services { get; }
    }
}