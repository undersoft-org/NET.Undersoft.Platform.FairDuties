﻿using System.Linq.Expressions;
using System.Uniques;

namespace UltimatR
{
    public class FindOneQuery<TStore, TEntity, TDto> : Query<TStore, TEntity, UniqueOne<TDto>>
        where TEntity : Entity where TStore : IDataStore where TDto : class, IUnique
    {
        public FindOneQuery(params object[] keys) : base(keys) { }
        public FindOneQuery(object[] keys, params Expression<Func<TEntity, object>>[] expanders) : base(keys, expanders) { }
        public FindOneQuery(Expression<Func<TEntity, bool>> predicate) : base(predicate) { }
        public FindOneQuery(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] expanders) : base(predicate, expanders) { }
    }
}
