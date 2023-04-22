using System.ServiceModel;

namespace RadicalR
{
    [ServiceContract]
    public interface IGrpcDataServiceController<TKey, TEntity, TDto> where TDto : Dto
    {
        Task<int> Count();
        Task<string[]> Delete(TDto[] dtos);
        Task<string[]> Delete(TKey key, TDto dto);
        Task<IEnumerable<TDto>> Get();
        Task<IEnumerable<TDto>> Get(int offset, int limit);
        Task<TDto> Get(TKey key);
        Task<string[]> Patch(TDto[] dtos);
        Task<string[]> Patch(TKey key, TDto dto);
        Task<IEnumerable<TDto>> Post(int offset, int limit, QueryItems query);
        Task<string[]> Post(TDto[] dtos);
        Task<string[]> Post(TKey key, TDto dto);
        Task<string[]> Put(TDto[] dtos);
        Task<string[]> Put(TKey key, TDto dto);
    }
}