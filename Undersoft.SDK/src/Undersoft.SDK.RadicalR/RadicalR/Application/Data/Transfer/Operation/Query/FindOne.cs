using System;
using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace RadicalR
{
    public class FindOne<TStore, TEntity, TDto> : Query<TStore, TEntity, TDto>
        where TEntity : Entity where TStore : IDataStore
    {
        public FindOne(params object[] keys) : base(keys) { }
        public FindOne(object[] keys, params Expression<Func<TEntity, object>>[] expanders) : base(keys, expanders) { }
        public FindOne(Expression<Func<TEntity, bool>> predicate) : base(predicate) { }
        public FindOne(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] expanders) : base(predicate, expanders) { }
    }
}
