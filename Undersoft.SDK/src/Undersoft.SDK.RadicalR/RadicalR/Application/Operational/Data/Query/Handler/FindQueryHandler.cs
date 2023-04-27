using MediatR;
using System.Uniques;

namespace RadicalR
{
    public class FindQueryHandler<TStore, TEntity, TDto> : IRequestHandler<FindQuery<TStore, TEntity, TDto>, UniqueOne<TDto>>
        where TEntity : Entity where TStore : IDataStore where TDto : class, IUnique
    {
        protected readonly IEntityRepository<TEntity> _repository;

        public FindQueryHandler(IEntityRepository<TStore, TEntity> repository)
        {
            _repository = repository;
        }

        public virtual Task<UniqueOne<TDto>> Handle(FindQuery<TStore, TEntity, TDto> request, CancellationToken cancellationToken)
        {
            Task<UniqueOne<TDto>> result = null;
            if (request.Keys != null)
                result = _repository.FindOneAsync<TDto>(request.Keys, request.Expanders);
            else
                result = _repository.FindOneAsync<TDto>(request.Predicate, request.Expanders);

            //result.Wait(30 * 1000);

            return result;
        }
    }
}
