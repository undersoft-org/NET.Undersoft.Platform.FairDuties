using System;
using System.Threading.Tasks;
using Undersoft.IDP.Admin.BusinessLogic.Dtos.Log;

namespace Undersoft.IDP.Admin.BusinessLogic.Services.Interfaces
{
    public interface IAuditLogService
    {
        Task<AuditLogsDto> GetAsync(AuditLogFilterDto filters);

        Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan);
    }
}
