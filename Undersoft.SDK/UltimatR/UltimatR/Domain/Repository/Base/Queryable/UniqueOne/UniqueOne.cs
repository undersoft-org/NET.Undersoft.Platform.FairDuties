using Microsoft.AspNetCore.OData.Results;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace System.Uniques
{

    public sealed class UniqueOne<T> : UniqueOne, IUniqueOne<T> where T : IUnique
    {
        public UniqueOne(T entity) : base(entity.ToQueryable())
        {
        }
        public UniqueOne(IEnumerable<T> enumerable) : base(enumerable.AsQueryable())
        {
        }
        public UniqueOne(IQueryable<T> queryable) : base(queryable)
        {
        }
        [JsonIgnore]
        public override IQueryable<T> Queryable => base.Queryable as IQueryable<T>;
    }


    public abstract class UniqueOne : SingleResult
    {
        public UniqueOne(object entity) : base(entity.ToQueryable())
        {
        }
        public UniqueOne(IQueryable queryable) : base(queryable)
        {
        }
        [JsonIgnore]
        public virtual new IQueryable Queryable => base.Queryable;
    }

    public static class UniqueoneExtensions
    {
        public static IQueryable<T> ToQueryable<T>(this T entity)
        {
            return ((entity == null) ? new T[0] : new T[1] { entity }).AsQueryable();
        }

        public static UniqueOne<T> AsUniqueOne<T>(this IQueryable<T> entity) where T : IUnique
        {
            return new UniqueOne<T>(entity);
        }

        public static UniqueOne<T> AsUniqueOne<T>(this IEnumerable<T> entity) where T : IUnique
        {
            return new UniqueOne<T>(entity);
        }

        public static UniqueOne<T> AsUniqueOne<T>(this T entity) where T : IUnique
        {
            return new UniqueOne<T>(entity);
        }
    }

    public interface IUniqueOne<T>
    {
        IQueryable<T> Queryable { get; }
    }

}
