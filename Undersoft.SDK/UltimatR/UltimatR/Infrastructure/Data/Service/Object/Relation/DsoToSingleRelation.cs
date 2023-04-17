using System;
using System.Linq;
using System.Linq.Expressions;

namespace UltimatR
{
    public class DsoToSingleRelation<TOrigin, TTarget> : DsoRelation<TOrigin, TTarget, TTarget> where TOrigin : class, IIdentifiable where TTarget : class, IIdentifiable
    {

        private Func<TTarget, object> targetKey;
        private Func<TOrigin, object> originKey;

        public DsoToSingleRelation() : base()
        {
        }
        public DsoToSingleRelation(Expression<Func<TOrigin, object>> originkey,
                                   Expression<Func<TTarget, object>> targetkey)
                                   : base()
        {
            Towards = Towards.ToSingle;
            OriginKey = originkey;
            TargetKey = targetkey;

            originKey = originkey.Compile();
            targetKey = targetkey.Compile();
        }

        public override Expression<Func<TTarget, bool>> CreatePredicate(object entity)
        {
            return LinqExtension.GetEqualityExpression(TargetKey, originKey, (TOrigin)entity);
        }
    }
}
