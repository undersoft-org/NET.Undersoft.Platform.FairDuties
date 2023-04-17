using System;
using System.Linq;
using System.Linq.Expressions;

namespace UltimatR
{
    public class GetQueryDto<TStore, TEntity, TDto> : Query<TStore, TEntity, IQueryable<TDto>>
        where TEntity : Entity where TStore : IDataStore
    {
        public GetQueryDto(params Expression<Func<TEntity, object>>[] expanders) : base(expanders)
        {
        }

        public GetQueryDto(SortExpression<TEntity> sortTerms, params Expression<Func<TEntity, object>>[] expanders) : base(sortTerms, expanders)
        {
        }
    }
}
