namespace System.Instant.Relationing
{
    using System.Extract;
    using System.Linq;
    using System.Uniques;

    [Serializable]
    public class RelationMember : IUnique
    {
        private Ussc serialcode;

        public RelationMember()
        {
            KeyRubrics = new MemberRubrics();
        }

        public RelationMember(ISleeve sleeve, Relation link, RelationSite site) : this()
        {
            string[] names = link.Name.Split("To");
            RelationMember member;
            Site = site;
            Relation = link;

            int siteId = 1;

            if (site == RelationSite.Origin)
            {
                siteId = 0;
                member = Relation.Origin;
            }
            else
                member = Relation.Target;

            Name = names[siteId];
            UniqueKey = names[siteId].UniqueKey64(link.UniqueKey);
            UniqueType = link.UniqueKey;
            Rubrics = sleeve.Rubrics;
            Sleeve = sleeve;
        }

        public RelationMember(Relation link, RelationSite site) : this()
        {
            string[] names = link.Name.Split("_&_");
            Site = site;
            Relation = link;
            RelationMember member;
            int siteId = 1;

            if (site == RelationSite.Origin)
            {
                siteId = 0;
                member = Relation.Origin;
            }
            else
                member = Relation.Target;

            Name = names[siteId];
            UniqueKey = names[siteId].UniqueKey64(link.UniqueKey);
            UniqueType = link.UniqueKey;
            Rubrics = member.Sleeve.Rubrics;
            Sleeve = member.Sleeve;
        }

        public IUnique Empty => Ussc.Empty;

        public ISleeve Sleeve { get; set; }

        public IRubrics KeyRubrics { get; set; }

        public Relation Relation { get; set; }

        public string Name { get; set; }

        public IRubrics Rubrics { get; set; }

        public Ussc SerialCode
        {
            get => serialcode;
            set => serialcode = value;
        }

        public RelationSite Site { get; set; }

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

        public unsafe ulong RelationKey(ISleeve figure)
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
    public class RelationNode : IUnique
    {
        private Ussc serialcode;

        public RelationNode()
        {
            OriginKeyRubrics = new MemberRubrics();
            TargetKeyRubrics = new MemberRubrics();
        }

        public RelationNode(ISleeve sleeve, Relation link) : this()
        {
            Name = link.Name;
            RelationNode member;
            Site = RelationSite.Node;
            Relation = link;

            member = Relation.Node;

            UniqueKey = Name.UniqueKey64(link.UniqueKey);
            UniqueType = link.UniqueKey;
            Rubrics = sleeve.Rubrics;
            Sleeve = sleeve;
        }

        public IUnique Empty => Ussc.Empty;

        public ISleeve Sleeve { get; set; }

        public IRubrics OriginKeyRubrics { get; set; }

        public IRubrics TargetKeyRubrics { get; set; }

        public Relation Relation { get; set; }

        public string Name { get; set; }

        public IRubrics Rubrics { get; set; }

        public Ussc SerialCode
        {
            get => serialcode;
            set => serialcode = value;
        }

        public RelationSite Site { get; set; }

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

        public unsafe ulong RelationOriginKey(ISleeve figure)
        {
            byte[] b = OriginKeyRubrics.Ordinals.SelectMany(x => figure[x].GetBytes()).ToArray();

            int l = b.Length;
            fixed (byte* pb = b)
            {
                return Hasher64.ComputeKey(pb, l);
            }
        }

        public unsafe ulong RelationTargetKey(ISleeve figure)
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
