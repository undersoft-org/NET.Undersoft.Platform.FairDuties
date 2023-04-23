using Microsoft.OData.Edm;
using RadicalR;

namespace Undersoft.ODP.Infra.Data.Service.Contexts
{
    public class EntryDataClient : EntityDataClient<IEntryStore>
    {
        public EntryDataClient(Uri serviceUri) : base(serviceUri)
        {
        }
    }

    public class ReportDataClient : EntityDataClient<IReportStore>
    {
        public ReportDataClient(Uri serviceUri) : base(serviceUri)
        {
        }
    }
     
    public class EntityDataClient<TStore> : DataClientContext<TStore> where TStore : IDataStore
    {
        public EntityDataClient(Uri serviceUri) : base(serviceUri)
        {
        }

        protected override IEdmModel OnModelCreating(IEdmModel builder)
        {
            return base.OnModelCreating(builder);
        }
    }
}