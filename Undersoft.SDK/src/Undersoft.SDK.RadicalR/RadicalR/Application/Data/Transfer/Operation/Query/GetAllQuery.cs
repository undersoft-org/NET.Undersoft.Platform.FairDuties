using System.Linq.Expressions;

namespace RadicalR
{
    public class GetAllQuery<TStore, TEntity, TDto> : Query<TStore, TEntity, IQueryable<TDto>>
        where TEntity : Entity where TStore : IDataStore
    {
        public GetAllQuery(params Expression<Func<TEntity, object>>[] expanders) : base(expanders)
        {
        }

        public GetAllQuery(SortExpression<TEntity> sortTerms, params Expression<Func<TEntity, object>>[] expanders) : base(sortTerms, expanders)
        {
        }
    }
}
