using System.Linq.Expressions;

namespace RadicalR
{
    public class RemoteLinkOnSet<TOrigin, TTarget> : RemoteLink<TOrigin, TTarget, RemoteOnSet<TTarget>> where TOrigin : class, IIdentifiable where TTarget : class, IIdentifiable
    {
        private Func<TTarget, object> targetKey;
        private Func<TOrigin, object> originKey;

        public RemoteLinkOnSet() : base()
        {
        }
        public RemoteLinkOnSet(Expression<Func<TOrigin, object>> originkey,
                                Expression<Func<TTarget, object>> targetkey)
                                    : base()
        {
            Towards = Towards.ToSet;
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
