namespace System.Instant.Linking
{
    using Linq;
    using Series;
    using Uniques;

    public interface ILinker
    {
        Links OriginLinks { get; }

        Links TargetLinks { get; }

        void Clear();

        Link GetOrigin(IFigure target, string OriginName);

        IDeck<Link> GetOrigins(IFigures target, string OriginName);

        Link GetTarget(IFigure origin, string TargetName);

        IDeck<Link> GetTargets(IFigures origin, string TargetName);
    }

    [Serializable]
    public class Linker
    {
        private static Catalog<Link> map = new Catalog<Link>(true, PRIMES_ARRAY.Get(9));
        private Links originLinks;
        private Links targetLinks;

        public Linker()
        {
            originLinks = new Links();
            targetLinks = new Links();
        }

        public static IDeck<Link> Map
        {
            get => map;
        }

        public Link Link { get; set; }

        public Links OriginLinks
        {
            get => originLinks;
        }

        public Links TargetLinks
        {
            get => targetLinks;
        }

        public void Clear()
        {
            Map.Flush();
        }

        public Link GetOrigin(ISleeve figure, string OriginName)
        {
            return map[OriginKey(figure, OriginName)];
        }

        public Link GetOriginLink(string OriginName)
        {
            return OriginLinks[OriginName + "_" + Link.Name];
        }

        public LinkMember GetOriginMember(string OriginName)
        {
            Link link = GetOriginLink(OriginName);
            if (link != null)
                return link.Origin;
            return null;
        }

        public IDeck<Link> GetOrigins(Links figures, string OriginName)
        {
            var originMember = GetOriginMember(OriginName);
            return new Album<Link>(
                figures.Select(f => map[originMember.LinkKey(f.ToSleeve())]),
                255
            );
        }

        public Link GetTarget(ISleeve figure, string TargetName)
        {
            return map[TargetKey(figure, TargetName)];
        }

        public Link GetTargetLink(string TargetName)
        {
            return TargetLinks[Link.Name + "_&_" + TargetName];
        }

        public LinkMember GetTargetMember(string TargetName)
        {
            Link link = GetTargetLink(TargetName);
            if (link != null)
                return link.Target;
            return null;
        }

        public IDeck<Link> GetTargets(IFigures figures, string TargetName)
        {
            var targetMember = GetTargetMember(TargetName);
            return new Album<Link>(
                figures.Select(f => map[targetMember.LinkKey(f.ToSleeve())]).ToArray(),
                255
            );
        }

        public ulong OriginKey(ISleeve figure, string OriginName)
        {
            return GetOriginMember(OriginName).LinkKey(figure);
        }

        public ulong TargetKey(ISleeve figure, string TargetName)
        {
            return GetTargetMember(TargetName).LinkKey(figure);
        }
    }

    public static class LinkerExtension
    {
        public static Link GetOriginLink(this Sleeve figures, string OriginName)
        {
            return Linker.Map[OriginName + "_" + figures.Name];
        }

        public static Link GetTargetLink(this Sleeve figures, string TargetName)
        {
            return Linker.Map[figures.Name + "_" + TargetName];
        }
    }
}
