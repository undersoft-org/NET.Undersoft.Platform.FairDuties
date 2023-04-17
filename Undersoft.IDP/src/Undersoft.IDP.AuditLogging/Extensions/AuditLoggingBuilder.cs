using Microsoft.Extensions.DependencyInjection;
using NicmanGroup.AuditLogging.EntityFramework.Extensions;

namespace NicmanGroup.AuditLogging.Extensions
{
    public class AuditLoggingBuilder : IAuditLoggingBuilder
    {
        public AuditLoggingBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}