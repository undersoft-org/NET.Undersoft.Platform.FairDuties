using Microsoft.OData.Client;
using System.Linq;

namespace UltimatR
{

    public class DsoSetToSet<TStore, TEntity> : DsoSet<TEntity>, IDsoSetToSet<TStore, TEntity> where TEntity : class, IIdentifiable
    {
        public DsoSetToSet(IRemoteRepository<TStore, TEntity> repository) : base(repository) { }
    }

    public class DsoSetToSet<TEntity> : DsoSet<TEntity> where TEntity : class, IIdentifiable
    {
        public DsoSetToSet() : base()
        {
        }
        public DsoSetToSet(DataServiceQuery<TEntity> query) : base(query)
        {
        }
        public DsoSetToSet(DsContext context, IQueryable<TEntity> query) : base(context, query)
        {
        }
        public DsoSetToSet(DsContext context) : base(context)
        {
        }
    }
}