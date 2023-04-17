namespace System.Instant.Linking
{
    using System.Extract;
    using System.Linq;
    using System.Uniques;

    [Serializable]
    public class LinkMember : IUnique
    {
        private Ussc serialcode;

        public LinkMember()
        {
            KeyRubrics = new MemberRubrics();
        }

        public LinkMember(ISleeve sleeve, Link link, LinkSite site) : this()
        {
            string[] names = link.Name.Split("To");
            LinkMember member;
            Site = site;
            Link = link;

            int siteId = 1;

            if (site == LinkSite.Origin)
            {
                siteId = 0;
                member = Link.Origin;
            }
            else
                member = Link.Target;

            Name = names[siteId];
            UniqueKey = names[siteId].UniqueKey64(link.UniqueKey);
            UniqueType = link.UniqueKey;
            Rubrics = sleeve.Rubrics;
            Sleeve = sleeve;
        }

        public LinkMember(Link link, LinkSite site) : this()
        {
            string[] names = link.Name.Split("_&_");
            Site = site;
            Link = link;
            LinkMember member;
            int siteId = 1;

            if (site == LinkSite.Origin)
            {
                siteId = 0;
                member = Link.Origin;
            }
            else
                member = Link.Target;

            Name = names[siteId];
            UniqueKey = names[siteId].UniqueKey64(link.UniqueKey);
            UniqueType = link.UniqueKey;
            Rubrics = member.Sleeve.Rubrics;
            Sleeve = member.Sleeve;
        }

        public IUnique Empty => Ussc.Empty;

        public ISleeve Sleeve { get; set; }

        public IRubrics KeyRubrics { get; set; }

        public Link Link { get; set; }

        public string Name { get; set; }

        public IRubrics Rubrics { get; set; }

        public Ussc SerialCode
        {
            get => serialcode;
            set => serialcode = value;
        }

        public LinkSite Site { get; set; }

        public ulong UniqueKey
        {
            get => serialcode.UniqueKey;
            set => serialcode.UniqueKey = value;
        }

        public ulong UniqueType
        {
            get => serialcode.UniqueType;
            set => serialcode.UniqueType = value;
        }

        public int CompareTo(IUnique other)
        {
            return SerialCode.CompareTo(other);
        }

        public bool Equals(IUnique other)
        {
            return SerialCode.Equals(other);
        }

        public byte[] GetBytes()
        {
            return serialcode.GetBytes();
        }

        public byte[] GetUniqueBytes()
        {
            return serialcode.GetUniqueBytes();
        }

        public unsafe ulong LinkKey(ISleeve figure)
        {
            byte[] b = KeyRubrics.Ordinals.SelectMany(x => figure[x].GetBytes()).ToArray();

            int l = b.Length;
            fixed (byte* pb = b)
            {
                return Hasher64.ComputeKey(pb, l);
            }
        }
    }

    [Serializable]
    public class LinkNode : IUnique
    {
        private Ussc serialcode;

        public LinkNode()
        {
            OriginKeyRubrics = new MemberRubrics();
            TargetKeyRubrics = new MemberRubrics();
        }

        public LinkNode(ISleeve sleeve, Link link) : this()
        {
            Name = link.Name;
            LinkNode member;
            Site = LinkSite.Node;
            Link = link;

            member = Link.Node;

            UniqueKey = Name.UniqueKey64(link.UniqueKey);
            UniqueType = link.UniqueKey;
            Rubrics = sleeve.Rubrics;
            Sleeve = sleeve;
        }

        public IUnique Empty => Ussc.Empty;

        public ISleeve Sleeve { get; set; }

        public IRubrics OriginKeyRubrics { get; set; }

        public IRubrics TargetKeyRubrics { get; set; }

        public Link Link { get; set; }

        public string Name { get; set; }

        public IRubrics Rubrics { get; set; }

        public Ussc SerialCode
        {
            get => serialcode;
            set => serialcode = value;
        }

        public LinkSite Site { get; set; }

        public ulong UniqueKey
        {
            get => serialcode.UniqueKey;
            set => serialcode.UniqueKey = value;
        }

        public ulong UniqueType
        {
            get => serialcode.UniqueType;
            set => serialcode.UniqueType = value;
        }

        public int CompareTo(IUnique other)
        {
            return SerialCode.CompareTo(other);
        }

        public bool Equals(IUnique other)
        {
            return SerialCode.Equals(other);
        }

        public byte[] GetBytes()
        {
            return serialcode.GetBytes();
        }

        public byte[] GetUniqueBytes()
        {
            return serialcode.GetUniqueBytes();
        }

        public unsafe ulong LinkOriginKey(ISleeve figure)
        {
            byte[] b = OriginKeyRubrics.Ordinals.SelectMany(x => figure[x].GetBytes()).ToArray();

            int l = b.Length;
            fixed (byte* pb = b)
            {
                return Hasher64.ComputeKey(pb, l);
            }
        }

        public unsafe ulong LinkTargetKey(ISleeve figure)
        {
            byte[] b = OriginKeyRubrics.Ordinals.SelectMany(x => figure[x].GetBytes()).ToArray();

            int l = b.Length;
            fixed (byte* pb = b)
            {
                return Hasher64.ComputeKey(pb, l);
            }
        }
    }
}
