using System.Series;

namespace RadicalR.Server
{
    public abstract class DataServiceBuilder : Catalog<Type>, IDataServiceBuilder
    {
        protected virtual Type StoreType { get; set; }

        public static DataServiceTypes ServiceTypes { get; set; }

        public string RoutePrefix { get; set; } = "";

        public int PageLimit { get; set; } = 10000;

        protected IDeck<Type> DataBaseContexts { get; set; } = new Deck<Type>();

        public DataServiceBuilder() : base()
        {
            RoutePrefix = GetRoutes();
        }

        public abstract void Build();

        protected virtual string GetRoutes()
        {
            if (StoreType == typeof(IEventStore))
            {
                return StoreRoutes.EventStore + RoutePrefix;
            }
            else
            {
                return StoreRoutes.DataStore + RoutePrefix;
            }
        }

        public virtual DataServiceBuilder AddDataService<TContext>() where TContext : RadicalR.DataBaseContext
        {
            TryAdd(typeof(TContext));
            return this;
        }
    }

    public enum DataServiceTypes
    {
        None = 0,
        Grpc = 1,
        OData = 2,
        Rest = 4,
        All = 7
    }
}
