using Microsoft.OData.Client;

namespace UltimatR
{
    public class RemoteOnSet<TStore, TDto> : RemoteSet<TDto>, IRemoteOnSet<TStore, TDto> where TDto : class, IIdentifiable
    {
        public RemoteOnSet(IRemoteRepository<TStore, TDto> repository) : base(repository) { }
    }

    public class RemoteOnSet<TDto> : RemoteSet<TDto> where TDto : class, IIdentifiable
    {
        public RemoteOnSet() : base()
        {
        }
        public RemoteOnSet(DataServiceQuery<TDto> query) : base(query)
        {
        }
        public RemoteOnSet(DsContext context, IQueryable<TDto> query) : base(context, query)
        {
        }
        public RemoteOnSet(DsContext context) : base(context)
        {
        }
    }
}