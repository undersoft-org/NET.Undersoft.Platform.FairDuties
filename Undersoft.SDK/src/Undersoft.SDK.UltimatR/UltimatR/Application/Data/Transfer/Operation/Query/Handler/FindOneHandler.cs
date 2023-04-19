using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace UltimatR
{
    public class FindOneHandler<TStore, TEntity, TDto> : IRequestHandler<FindOne<TStore, TEntity, TDto>, TDto>  
        where TEntity : Entity where TStore : IDataStore
    {
        protected readonly IEntityRepository<TEntity> _repository;

        public FindOneHandler(IEntityRepository<TStore, TEntity> repository)
        {
            _repository = repository;
        }

        public virtual Task<TDto> Handle(FindOne<TStore, TEntity, TDto> request, CancellationToken cancellationToken)
        {
            if(request.Keys != null)
                return _repository.Find<TDto>(request.Keys, request.Expanders);
            return _repository.Find<TDto>(request.Predicate, false, request.Expanders);
        }
    }
}
