using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using System.Uniques;

namespace RadicalR
{
    public interface IOpenDataServiceController<TKey, TEntity, TDto> where TDto : Dto
    {
        Task<IActionResult> Delete([FromODataUri] TKey key);
        IQueryable<TDto> Get();
        Task<UniqueOne<TDto>> Get([FromODataUri] TKey key);
        Task<IActionResult> Patch([FromODataUri] TKey key, [FromODataBody] TDto dto);
        Task<IActionResult> Post([FromODataBody] TDto dto);
        Task<IActionResult> Put([FromODataUri] TKey key, [FromODataBody] TDto dto);
    }
}