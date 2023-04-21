using MediatR;
using System.Uniques;

namespace UltimatR
{
    public class FindOneQueryHandler<TStore, TEntity, TDto> : IRequestHandler<FindOneQuery<TStore, TEntity, TDto>, UniqueOne<TDto>>
        where TEntity : Entity where TStore : IDataStore where TDto : class, IUnique
    {
        protected readonly IEntityRepository<TEntity> _repository;

        public FindOneQueryHandler(IEntityRepository<TStore, TEntity> repository)
        {
            _repository = repository;
        }

        public virtual Task<UniqueOne<TDto>> Handle(FindOneQuery<TStore, TEntity, TDto> request, CancellationToken cancellationToken)
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
