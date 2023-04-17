using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Uniques;

namespace UltimatR
{
    [ServiceContract]
    public interface IDsoController<TKey, TStore, TEntity> where TEntity : Entity where TStore : IDataStore
    {
        Task<IActionResult> Delete([FromODataUri] TKey key);
        IQueryable Get();
        UniqueOne Get([FromODataUri] TKey key);
        Task<IActionResult> Patch([FromODataUri] TKey key, TEntity entity);
        Task<IActionResult> Post(TEntity entity);
        Task<IActionResult> Put([FromODataUri] TKey key, TEntity entity);
    }
}