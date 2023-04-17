using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NicmanGroup.AuditLogging.EntityFramework.Entities;

namespace NicmanGroup.AuditLogging.EntityFramework.DbContexts
{
    public interface IAuditLoggingDbContext<TAuditLog> where TAuditLog : AuditLog
    {
        DbSet<TAuditLog> AuditLog { get; set; }

        Task<int> SaveChangesAsync();
    }
}