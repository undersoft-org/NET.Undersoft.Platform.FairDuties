using MediatR;
using System.Series;
using System.Threading;
using System.Threading.Tasks;

namespace UltimatR
{
    public class GetAllHandler<TStore, TEntity, TDto> : IRequestHandler<GetAll<TStore, TEntity, TDto>, IDeck<TDto>>
        where TEntity : Entity where TStore : IDataStore
    {
        protected readonly IEntityRepository<TEntity> _repository;

        public GetAllHandler(IEntityRepository<TStore, TEntity> repository)
        {
            _repository = repository;
        }

        public virtual Task<IDeck<TDto>> Handle(GetAll<TStore, TEntity, TDto> request,
                                                CancellationToken cancellationToken)
        {
            return _repository.Get<TDto>(request.Offset, request.Limit, request.Sort, request.Expanders);
        }
    }
}
