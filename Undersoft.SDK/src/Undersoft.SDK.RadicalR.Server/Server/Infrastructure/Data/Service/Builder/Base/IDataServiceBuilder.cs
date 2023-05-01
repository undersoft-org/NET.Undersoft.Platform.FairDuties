namespace RadicalR.Server
{
    public interface IDataServiceBuilder<TStore> : IDataServiceBuilder where TStore : IDataServiceStore { }

    public interface IDataServiceBuilder : IDisposable, IAsyncDisposable
    {
        string RoutePrefix { get; set; }

        int PageLimit { get; set; }

        void Build();

        DataServiceBuilder AddDataService<TContext>() where TContext : RadicalR.DataBaseContext;
    }
}
