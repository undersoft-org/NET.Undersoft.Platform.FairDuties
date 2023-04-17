using Microsoft.EntityFrameworkCore;
using Undersoft.IDP.Admin.EntityFramework.Entities;

namespace Undersoft.IDP.Admin.EntityFramework.Interfaces
{
    public interface IAdminLogDbContext
    {
        DbSet<Log> Logs { get; set; }
    }
}
