using MediatR;

namespace RadicalR
{
    public class GetAllQueryHandler<TStore, TEntity, TDto> : IRequestHandler<GetAllQuery<TStore, TEntity, TDto>, IQueryable<TDto>>
        where TEntity : Entity where TStore : IDataStore where TDto : class
    {
        protected readonly IEntityRepository<TEntity> _repository;

        public GetAllQueryHandler(IEntityRepository<TStore, TEntity> repository)
        {
            _repository = repository;
        }

        public virtual Task<IQueryable<TDto>> Handle(GetAllQuery<TStore, TEntity, TDto> request,
                                                CancellationToken cancellationToken)
        {
            var result = _repository.GetQueryAsync<TDto>(request.Sort, request.Expanders);

            result.Wait(30 * 1000);

            return result;
        }
    }
}
