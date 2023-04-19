using Microsoft.OData.Edm;
using UltimatR;

namespace Undersoft.ODP.Infra.Data.Service.Contexts
{
    public class EntryDsContext : EntityDsContext<IEntryStore>
    {
        public EntryDsContext(Uri serviceUri) : base(serviceUri)
        {
        }
    }

    public class ReportDsContext : EntityDsContext<IReportStore>
    {
        public ReportDsContext(Uri serviceUri) : base(serviceUri)
        {
        }
    }

    public class EntityDsContext<TStore> : DataClientContext<TStore> where TStore : IDataStore
    {
        public EntityDsContext(Uri serviceUri) : base(serviceUri)
        {
        }

        protected override IEdmModel OnModelCreating(IEdmModel builder)
        {
            return base.OnModelCreating(builder);
        }
    }
}