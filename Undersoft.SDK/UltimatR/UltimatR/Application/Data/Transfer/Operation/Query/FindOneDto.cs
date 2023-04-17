using System;
using System.Linq.Expressions;
using System.Uniques;

namespace UltimatR
{
    public class FindOneDto<TStore, TEntity, TDto> : Query<TStore, TEntity, UniqueOne<TDto>>
        where TEntity : Entity where TStore : IDataStore where TDto : class, IUnique
    {
        public FindOneDto(params object[] keys) : base(keys) { }
        public FindOneDto(object[] keys, params Expression<Func<TEntity, object>>[] expanders) : base(keys, expanders) { }
        public FindOneDto(Expression<Func<TEntity, bool>> predicate) : base(predicate) { }
        public FindOneDto(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] expanders) : base(predicate, expanders) { }
    }
}
