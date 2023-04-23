using Microsoft.EntityFrameworkCore;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Base.Contexts
{
    public class ReportDb : EntityDb<IReportStore, ReportDb>
    {
        public ReportDb(DbContextOptions<ReportDb> options) : base(options) { }
    }
}
