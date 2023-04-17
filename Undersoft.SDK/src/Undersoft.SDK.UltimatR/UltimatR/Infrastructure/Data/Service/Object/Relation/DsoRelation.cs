using System;
using System.Collections.Generic;
using System.Instant;
using System.Linq.Expressions;
using System.Uniques;

namespace UltimatR
{
    public interface IDsoRelation<TOrigin, TTarget> : IDsoRelation where TOrigin : class, IIdentifiable where TTarget : class, IIdentifiable
    {
        Expression<Func<TOrigin, object>> OriginKey { get; set; }
        Expression<Func<TTarget, object>> TargetKey { get; set; }

        Func<TOrigin, Expression<Func<TTarget, bool>>> Predicate { get; set; }

        Expression<Func<TTarget, bool>> CreatePredicate(object entity);
    }

    public interface IDsoRelation<TOrigin, TTarget, TMiddle> : IDsoRelation<TOrigin, TTarget> where TOrigin : class, IIdentifiable where TTarget : class, IIdentifiable
    {
        Expression<Func<TMiddle, object>> MiddleKey { get; set; }

        Expression<Func<TOrigin, IEnumerable<TMiddle>>> MiddleSet { get; set; }
    }

    public abstract class DsoRelation<TOrigin, TTarget, TMiddle> : DsoRelation, IDsoRelation<TOrigin, TTarget, TMiddle>
        where TOrigin : class, IIdentifiable where TTarget : class, IIdentifiable
    {
        public DsoRelation()
        {
            var key = typeof(TTarget).Name.UniqueBytes64();
            var seed = typeof(TOrigin).FullName.UniqueKey32();
            serialcode = new Uscn(key, seed);
            Name = typeof(TOrigin).Name + '_' + typeof(TTarget).Name;

            DsRegistry.Relations.Add(UniqueType, this);

            DsRegistry.Relations.Add(typeof(TTarget).Name.UniqueKey64(seed), this);

            ServiceManager.GetManager().Registry.AddObject<IDsoRelation<TOrigin, TTarget>>(this);
        }

        public virtual string Name { get; set; }

        public virtual Expression<Func<TOrigin, object>> OriginKey { get; set; }
        public virtual Expression<Func<TMiddle, object>> MiddleKey { get; set; }
        public virtual Expression<Func<TTarget, object>> TargetKey { get; set; }

        public virtual Func<TOrigin, Expression<Func<TTarget, bool>>> Predicate { get; set; }

        public virtual Expression<Func<TOrigin, IEnumerable<TMiddle>>> MiddleSet { get; set; }

        public abstract Expression<Func<TTarget, bool>> CreatePredicate(object entity);

        public override MemberRubric LinkedMember => DbRegistry.GetLinkedMember<TOrigin, TTarget>();

    }
}
