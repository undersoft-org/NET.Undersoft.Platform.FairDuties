using System;
using System.Threading.Tasks;
using Undersoft.IDP.Admin.EntityFramework.Entities;
using Undersoft.IDP.Admin.EntityFramework.Extensions.Common;

namespace Undersoft.IDP.Admin.EntityFramework.Repositories.Interfaces
{
    public interface ILogRepository
    {
        Task<PagedList<Log>> GetLogsAsync(string search, int page = 1, int pageSize = 10);

        Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan);

        bool AutoSaveChanges { get; set; }
    }
}