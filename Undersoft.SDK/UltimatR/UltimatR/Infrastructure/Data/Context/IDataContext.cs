using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace UltimatR
{
    public interface IDataContext<TStore> : IDataContext where TStore : IDataStore { }

    public interface IDataContext : IDisposable, IAsyncDisposable
    {
        IModel Model { get; }

        object DataSet<TEntity>() where TEntity : class, IIdentifiable;

        object DataSet(Type entityType);

        TModel GetModel<TModel>();
    }
}
