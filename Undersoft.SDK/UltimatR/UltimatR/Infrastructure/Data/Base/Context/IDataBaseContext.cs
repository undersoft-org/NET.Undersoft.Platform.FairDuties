using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UltimatR
{
    public interface IDataBaseContext<TStore> : IDataBaseContext where TStore : IDataStore { }

    public interface IDataBaseContext : IDataContext, IResettableService, IDisposable, IAsyncDisposable
    {
        Task<int> Save(bool asTransaction, CancellationToken token = default(CancellationToken));
    }
}
