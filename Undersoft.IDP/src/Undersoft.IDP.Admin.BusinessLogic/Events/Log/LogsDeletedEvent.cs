using System;
using NicmanGroup.AuditLogging.Events;

namespace Undersoft.IDP.Admin.BusinessLogic.Events.Log
{
    public class LogsDeletedEvent : AuditEvent
    {
        public DateTime DeleteOlderThan { get; set; }

        public LogsDeletedEvent(DateTime deleteOlderThan)
        {
            DeleteOlderThan = deleteOlderThan;
        }
    }
}