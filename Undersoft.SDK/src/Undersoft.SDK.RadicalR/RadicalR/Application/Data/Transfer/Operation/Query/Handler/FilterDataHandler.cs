using System.Series;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace RadicalR
{
    public class FilterDataHandler<TStore, TEntity, TDto>
        : IRequestHandler<FilterData<TStore, TEntity, TDto>, IDeck<TDto>>
        where TEntity : Entity
        where TStore : IDataStore
    {
        protected readonly IEntityRepository<TEntity> _repository;

        public FilterDataHandler(IEntityRepository<TStore, TEntity> repository)
        {
            _repository = repository;
        }

        public virtual Task<IDeck<TDto>> Handle(
            FilterData<TStore, TEntity, TDto> request,
            CancellationToken cancellationToken
        )
        {
            if (request.Predicate == null)
                return _repository.Filter<TDto>(
                    request.Offset,
                    request.Limit,
                    request.Sort,
                    request.Expanders
                );
            return _repository.Filter<TDto>(
                request.Offset,
                request.Limit,
                request.Predicate,
                request.Sort,
                request.Expanders
            );
        }
    }
}
