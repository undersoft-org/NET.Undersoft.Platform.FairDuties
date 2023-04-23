namespace System.Instant.Relationing
{
    using Linq;
    using Series;
    using Uniques;

    public interface IRelationer
    {
        Relations OriginRelations { get; }

        Relations TargetRelations { get; }

        void Clear();

        Relation GetOrigin(IFigure target, string OriginName);

        IDeck<Relation> GetOrigins(IFigures target, string OriginName);

        Relation GetTarget(IFigure origin, string TargetName);

        IDeck<Relation> GetTargets(IFigures origin, string TargetName);
    }

    [Serializable]
    public class Relationer
    {
        private static Catalog<Relation> map = new Catalog<Relation>(true, PRIMES_ARRAY.Get(9));
        private Relations originRelations;
        private Relations targetRelations;

        public Relationer()
        {
            originRelations = new Relations();
            targetRelations = new Relations();
        }

        public static IDeck<Relation> Map
        {
            get => map;
        }

        public Relation Relation { get; set; }

        public Relations OriginRelations
        {
            get => originRelations;
        }

        public Relations TargetRelations
        {
            get => targetRelations;
        }

        public void Clear()
        {
            Map.Flush();
        }

        public Relation GetOrigin(ISleeve figure, string OriginName)
        {
            return map[OriginKey(figure, OriginName)];
        }

        public Relation GetOriginRelation(string OriginName)
        {
            return OriginRelations[OriginName + "_" + Relation.Name];
        }

        public RelationMember GetOriginMember(string OriginName)
        {
            Relation link = GetOriginRelation(OriginName);
            if (link != null)
                return link.Origin;
            return null;
        }

        public IDeck<Relation> GetOrigins(Relations figures, string OriginName)
        {
            var originMember = GetOriginMember(OriginName);
            return new Album<Relation>(
                figures.Select(f => map[originMember.RelationKey(f.ToSleeve())]),
                255
            );
        }

        public Relation GetTarget(ISleeve figure, string TargetName)
        {
            return map[TargetKey(figure, TargetName)];
        }

        public Relation GetTargetRelation(string TargetName)
        {
            return TargetRelations[Relation.Name + "_&_" + TargetName];
        }

        public RelationMember GetTargetMember(string TargetName)
        {
            Relation link = GetTargetRelation(TargetName);
            if (link != null)
                return link.Target;
            return null;
        }

        public IDeck<Relation> GetTargets(IFigures figures, string TargetName)
        {
            var targetMember = GetTargetMember(TargetName);
            return new Album<Relation>(
                figures.Select(f => map[targetMember.RelationKey(f.ToSleeve())]).ToArray(),
                255
            );
        }

        public ulong OriginKey(ISleeve figure, string OriginName)
        {
            return GetOriginMember(OriginName).RelationKey(figure);
        }

        public ulong TargetKey(ISleeve figure, string TargetName)
        {
            return GetTargetMember(TargetName).RelationKey(figure);
        }
    }

    public static class RelationerExtension
    {
        public static Relation GetOriginRelation(this Sleeve figures, string OriginName)
        {
            return Relationer.Map[OriginName + "_" + figures.Name];
        }

        public static Relation GetTargetRelation(this Sleeve figures, string TargetName)
        {
            return Relationer.Map[figures.Name + "_" + TargetName];
        }
    }
}
