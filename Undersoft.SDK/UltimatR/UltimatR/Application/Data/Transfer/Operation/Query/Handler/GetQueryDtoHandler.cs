using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace UltimatR
{
    public class GetQueryDtoHandler<TStore, TEntity, TDto> : IRequestHandler<GetQueryDto<TStore, TEntity, TDto>, IQueryable<TDto>>
        where TEntity : Entity where TStore : IDataStore where TDto : class
    {
        protected readonly IEntityRepository<TEntity> _repository;

        public GetQueryDtoHandler(IEntityRepository<TStore, TEntity> repository)
        {
            _repository = repository;
        }

        public virtual Task<IQueryable<TDto>> Handle(GetQueryDto<TStore, TEntity, TDto> request,
                                                CancellationToken cancellationToken)
        {
            return _repository.GetQueryAsync<TDto>(request.Sort, request.Expanders);
        }
    }
}
