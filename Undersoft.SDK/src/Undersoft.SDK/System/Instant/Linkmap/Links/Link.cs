namespace System.Instant.Linking
{
    using System.Uniques;

    [Serializable]
    public class Link : IUniqueCode
    {
        private Uscn uniquecode;

        public Link() { }

        public Link(ISleeve origin, ISleeve target)
        {
            LinkPair(origin, target);
        }

        public Link(ISleeve origin, ISleeve target, IRubrics parentKeys, IRubrics childKeys)
            : this(origin, target)
        {
            LinkParentKeys(parentKeys);
            LinkChildKeys(childKeys);
        }

        public Link(ISleeve origin, ISleeve target, string[] parentKeys, string[] childKeys)
            : this(origin, target)
        {
            LinkParentKeys(parentKeys);
            LinkChildKeys(childKeys);
        }

        public Link(ISleeve origin, ISleeve node, ISleeve target)
        {
            LinkTrio(origin, node, target);
        }

        public Link(
            ISleeve origin,
            ISleeve node,
            ISleeve target,
            IRubrics parentKeys,
            IRubrics nodeParentKeys,
            IRubrics nodeChildKeys,
            IRubrics childKeys
        ) : this(origin, node, target)
        {
            LinkParentKeys(parentKeys);
            LinkNodeKeys(nodeParentKeys, nodeChildKeys);
            LinkChildKeys(childKeys);
        }

        public Link(
            ISleeve origin,
            ISleeve node,
            ISleeve target,
            string[] parentKeys,
            string[] nodeParentKeys,
            string[] nodeChildKeys,
            string[] childKeys
        ) : this(origin, node, target)
        {
            LinkParentKeys(parentKeys);
            LinkNodeKeys(nodeParentKeys, nodeParentKeys);
            LinkChildKeys(childKeys);
        }

        public IUnique Empty => Uscn.Empty;

        public string Name { get; set; }

        public LinkMember Origin { get; set; }

        public IRubrics OriginKeys
        {
            get { return Origin.KeyRubrics; }
            set
            {
                Origin.KeyRubrics.Renew(value);
                Origin.KeyRubrics.Update();
            }
        }

        public string OriginName
        {
            get { return Origin.Name; }
            set { Origin.Name = value; }
        }

        public IRubrics OriginRubrics
        {
            get { return Origin.Rubrics; }
            set { Origin.Rubrics = value; }
        }

        public Uscn UniqueCode
        {
            get => uniquecode;
            set => uniquecode = value;
        }

        public LinkNode Node { get; set; }

        public IRubrics NodeOriginKeys
        {
            get { return Node.OriginKeyRubrics; }
            set
            {
                Node.OriginKeyRubrics.Renew(value);
                Node.OriginKeyRubrics.Update();
            }
        }

        public IRubrics NodeTargetKeys
        {
            get { return Node.TargetKeyRubrics; }
            set
            {
                Node.TargetKeyRubrics.Renew(value);
                Node.TargetKeyRubrics.Update();
            }
        }

        public string NodeName
        {
            get { return Node.Name; }
            set { Node.Name = value; }
        }

        public IRubrics NodeRubrics
        {
            get { return Node.Rubrics; }
            set { Node.Rubrics = value; }
        }

        public LinkMember Target { get; set; }

        public IRubrics TargetKeys
        {
            get { return Target.KeyRubrics; }
            set
            {
                Target.KeyRubrics.Renew(value);
                Target.KeyRubrics.Update();
            }
        }

        public string TargetName
        {
            get { return Target.Name; }
            set { Target.Name = value; }
        }

        public IRubrics TargetRubrics
        {
            get { return Target.KeyRubrics; }
            set { Target.KeyRubrics = value; }
        }

        public ulong UniqueKey
        {
            get => uniquecode.UniqueKey;
            set => uniquecode.UniqueKey = value;
        }

        public ulong UniqueType
        {
            get => uniquecode.UniqueType;
            set => uniquecode.UniqueType = value;
        }

        public int CompareTo(IUnique other)
        {
            return uniquecode.CompareTo(other);
        }

        public bool Equals(IUnique other)
        {
            return uniquecode.Equals(other);
        }

        public byte[] GetBytes()
        {
            return uniquecode.GetBytes();
        }

        public byte[] GetUniqueBytes()
        {
            return uniquecode.GetUniqueBytes();
        }

        public Link SetLink(ISleeve origin, ISleeve target, IRubrics parentKeys, IRubrics childKeys)
        {
            LinkPair(origin, target);
            LinkParentKeys(parentKeys);
            LinkChildKeys(childKeys);
            return this;
        }

        public Link SetLink(
            ISleeve origin,
            ISleeve target,
            string[] parentKeynames,
            string[] childKeynames
        )
        {
            LinkPair(origin, target);
            LinkParentKeys(parentKeynames);
            LinkChildKeys(childKeynames);
            return this;
        }

        public Link LinkPair(ISleeve origin, ISleeve target)
        {
            Name = origin.GetType().Name + "To" + target.GetType().Name;

            UniqueKey = Name.UniqueKey64();
            UniqueType = Name.UniqueKey32();

            Origin = new LinkMember(origin, this, LinkSite.Origin);
            Target = new LinkMember(target, this, LinkSite.Target);

            return Linker.Map.Put(this).Value;
        }

        public Link LinkTrio(ISleeve origin, ISleeve node, ISleeve target)
        {
            Name = origin.GetType().Name + "To" + target.GetType().Name;

            UniqueKey = Name.UniqueKey64();
            UniqueType = Name.UniqueKey32();

            Origin = new LinkMember(origin, this, LinkSite.Origin);
            Node = new LinkNode(node, this);
            Target = new LinkMember(target, this, LinkSite.Target);

            return Linker.Map.Put(this).Value;
        }

        public void LinkParentKeys(IRubrics keyRubrics)
        {
            foreach (IUnique rubric in keyRubrics)
            {
                var originRubric = Origin.Rubrics[rubric];
                if (originRubric != null)
                {
                    OriginKeys.Add(originRubric);
                }
                else
                    throw new IndexOutOfRangeException("Rubric not found");
                OriginKeys.Update();
            }
        }

        public void LinkNodeKeys(IRubrics originKeyRubric, IRubrics targetKeyRubric)
        {
            foreach (var rubric in originKeyRubric)
            {
                var nodeRubric = Node.Rubrics[rubric];
                if (nodeRubric != null)
                {
                    NodeOriginKeys.Add(nodeRubric);
                }
                else
                    throw new IndexOutOfRangeException("Rubric not found");
            }
            foreach (var rubric in targetKeyRubric)
            {
                var nodeRubric = Node.Rubrics[rubric];
                if (nodeRubric != null)
                {
                    NodeTargetKeys.Add(nodeRubric);
                }
                else
                    throw new IndexOutOfRangeException("Rubric not found");
            }

            OriginKeys.Update();
            NodeOriginKeys.Update();
            NodeTargetKeys.Update();
            TargetKeys.Update();
        }

        public void LinkChildKeys(IRubrics keyRubrics)
        {
            foreach (IUnique rubric in keyRubrics)
            {
                var targetRubric = Target.Rubrics[rubric];
                if (targetRubric != null)
                {
                    TargetKeys.Add(targetRubric);
                }
                else
                    throw new IndexOutOfRangeException("Rubric not found");
                TargetKeys.Update();
            }
        }

        public void LinkChildKeys(string[] keyRubricNames)
        {
            foreach (var name in keyRubricNames)
            {
                var targetRubric = Target.Rubrics[name];
                if (targetRubric != null)
                {
                    TargetKeys.Add(targetRubric);
                }
                else
                    throw new IndexOutOfRangeException("Rubric not found");
            }
            OriginKeys.Update();
            TargetKeys.Update();
        }

        public void LinkNodeKeys(string[] originKeyRubricNames, string[] targetKeyRubricNames)
        {
            foreach (var name in originKeyRubricNames)
            {
                var nodeRubric = Node.Rubrics[name];
                if (nodeRubric != null)
                {
                    NodeOriginKeys.Add(nodeRubric);
                }
                else
                    throw new IndexOutOfRangeException("Rubric not found");
            }
            foreach (var name in targetKeyRubricNames)
            {
                var nodeRubric = Node.Rubrics[name];
                if (nodeRubric != null)
                {
                    NodeTargetKeys.Add(nodeRubric);
                }
                else
                    throw new IndexOutOfRangeException("Rubric not found");
            }

            OriginKeys.Update();
            NodeOriginKeys.Update();
            NodeTargetKeys.Update();
            TargetKeys.Update();
        }

        public void LinkParentKeys(string[] keyRubricNames)
        {
            foreach (var name in keyRubricNames)
            {
                var originRubric = Origin.Rubrics[name];
                if (originRubric != null)
                {
                    OriginKeys.Add(originRubric);
                }
                else
                    throw new IndexOutOfRangeException("Rubric not found");
            }
            OriginKeys.Update();
            TargetKeys.Update();
        }
    }
}
