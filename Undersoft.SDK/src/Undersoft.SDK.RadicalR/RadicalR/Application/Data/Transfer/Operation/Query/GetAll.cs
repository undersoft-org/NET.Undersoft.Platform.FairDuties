using System.Linq.Expressions;
using System.Series;

namespace RadicalR
{
    public class GetAll<TStore, TEntity, TDto> : Query<TStore, TEntity, IDeck<TDto>>
        where TEntity : Entity where TStore : IDataStore
    {
        public GetAll(int offset, int limit, params Expression<Func<TEntity, object>>[] expanders) : base(expanders)
        {
            Offset = offset;
            Limit = limit;
        }

        public GetAll(int offset, int limit, SortExpression<TEntity> sortTerms, params Expression<Func<TEntity, object>>[] expanders) : base(sortTerms, expanders)
        {
            Offset = offset;
            Limit = limit;
        }
    }
}
