using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Uniques;

namespace UltimatR
{
    public class FindOneDtoHandler<TStore, TEntity, TDto> : IRequestHandler<FindOneDto<TStore, TEntity, TDto>, UniqueOne<TDto>>
        where TEntity : Entity where TStore : IDataStore where TDto : class, IUnique
    {
        protected readonly IEntityRepository<TEntity> _repository;

        public FindOneDtoHandler(IEntityRepository<TStore, TEntity> repository)
        {
            _repository = repository;
        }

        public virtual Task<UniqueOne<TDto>> Handle(FindOneDto<TStore, TEntity, TDto> request, CancellationToken cancellationToken)
        {
            if (request.Keys != null)
                return _repository.FindOneAsync<TDto>(request.Keys, request.Expanders);
            return _repository.FindOneAsync<TDto>(request.Predicate, request.Expanders);
        }
    }
}
