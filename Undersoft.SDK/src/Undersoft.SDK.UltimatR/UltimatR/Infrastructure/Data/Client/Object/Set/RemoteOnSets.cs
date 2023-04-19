using Microsoft.OData.Client;

namespace UltimatR
{

    public class RemoteOnSets<TStore, TEntity> : RemoteSet<TEntity>, IRemoteOnSets<TStore, TEntity> where TEntity : class, IIdentifiable
    {
        public RemoteOnSets(IRemoteRepository<TStore, TEntity> repository) : base(repository) { }
    }

    public class DsoSetToSet<TEntity> : RemoteSet<TEntity> where TEntity : class, IIdentifiable
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