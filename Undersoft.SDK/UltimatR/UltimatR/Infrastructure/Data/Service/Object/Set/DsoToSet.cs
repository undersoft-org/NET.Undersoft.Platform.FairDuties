using Microsoft.OData.Client;
using System.Linq;

namespace UltimatR
{
    public class DsoToSet<TStore, TEntity> : DsoSet<TEntity>, IDsoToSet<TStore, TEntity> where TEntity : class, IIdentifiable
    {
        public DsoToSet(IRemoteRepository<TStore, TEntity> repository) : base(repository) { }
    }

    public class DsoToSet<TEntity> : DsoSet<TEntity> where TEntity : class, IIdentifiable
    {
        public DsoToSet() : base()
        {
        }
        public DsoToSet(DataServiceQuery<TEntity> query) : base(query)
        {
        }
        public DsoToSet(DsContext context, IQueryable<TEntity> query) : base(context, query)
        {
        }
        public DsoToSet(DsContext context) : base(context)
        {
        }
    }
}