using System;
using System.Threading.Tasks;
using NicmanGroup.AuditLogging.EntityFramework.Entities;
using NicmanGroup.AuditLogging.EntityFramework.Mapping;
using NicmanGroup.AuditLogging.EntityFramework.Repositories;
using NicmanGroup.AuditLogging.Events;
using NicmanGroup.AuditLogging.Services;

namespace NicmanGroup.AuditLogging.EntityFramework.Services
{
    public class DatabaseAuditEventLoggerSink<TAuditLog> : IAuditEventLoggerSink 
        where TAuditLog : AuditLog, new()
    {
        private readonly IAuditLoggingRepository<TAuditLog> _auditLoggingRepository;

        public DatabaseAuditEventLoggerSink(IAuditLoggingRepository<TAuditLog> auditLoggingRepository)
        {
            _auditLoggingRepository = auditLoggingRepository;
        }

        public virtual async Task PersistAsync(AuditEvent auditEvent)
        {
            if (auditEvent == null) throw new ArgumentNullException(nameof(auditEvent));

            var auditLog = auditEvent.MapToEntity<TAuditLog>();

            await _auditLoggingRepository.SaveAsync(auditLog);
        }
    }
}