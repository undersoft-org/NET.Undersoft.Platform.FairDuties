using System.ServiceModel;

namespace RadicalR.Server
{
    [ServiceContract]
    public interface IStreamEventController<TDto> where TDto : Dto
    {
        Task<int> Count();
        IAsyncEnumerable<TDto> All();
        IAsyncEnumerable<TDto> Range(int offset, int limit);
        IAsyncEnumerable<TDto> Query(int offset, int limit, QueryItems query);
        IAsyncEnumerable<string> Creates(TDto[] dtos); 
        IAsyncEnumerable<string> Changes(TDto[] dtos);
        IAsyncEnumerable<string> Updates(TDto[] dtos);
        IAsyncEnumerable<string> Deletes(TDto[] dtos);
    }
}