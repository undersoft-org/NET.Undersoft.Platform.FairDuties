using System.ServiceModel;

namespace RadicalR
{
    [ServiceContract]
    public interface IGrpcDataServiceController<TKey, TEntity, TDto> where TDto : Dto
    {
        Task<int> Count();
        Task<IEnumerable<TDto>> All();
        Task<IEnumerable<TDto>> Range(int offset, int limit);
        Task<IEnumerable<TDto>> Query(int offset, int limit, QueryItems query);
        Task<IEnumerable<string>> Creates(TDto[] dtos);
        Task<IEnumerable<string>> Changes(TDto[] dtos);
        Task<IEnumerable<string>> Updates(TDto[] dtos);
        Task<IEnumerable<string>> Deletes(TDto[] dtos);
    }
}