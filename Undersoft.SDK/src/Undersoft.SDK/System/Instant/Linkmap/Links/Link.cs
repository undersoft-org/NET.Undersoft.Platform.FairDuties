namespace System.Instant.Relationing
{
    using System.Uniques;

    [Serializable]
    public class Relation : IUniqueCode
    {
        private Uscn uniquecode;

        public Relation() { }

        public Relation(ISleeve origin, ISleeve target)
        {
            RelationPair(origin, target);
        }

        public Relation(ISleeve origin, ISleeve target, IRubrics parentKeys, IRubrics childKeys)
            : this(origin, target)
        {
            RelationParentKeys(parentKeys);
            RelationChildKeys(childKeys);
        }

        public Relation(ISleeve origin, ISleeve target, string[] parentKeys, string[] childKeys)
            : this(origin, target)
        {
            RelationParentKeys(parentKeys);
            RelationChildKeys(childKeys);
        }

        public Relation(ISleeve origin, ISleeve node, ISleeve target)
        {
            RelationTrio(origin, node, target);
        }

        public Relation(
            ISleeve origin,
            ISleeve node,
            ISleeve target,
            IRubrics parentKeys,
            IRubrics nodeParentKeys,
            IRubrics nodeChildKeys,
            IRubrics childKeys
        ) : this(origin, node, target)
        {
            RelationParentKeys(parentKeys);
            RelationNodeKeys(nodeParentKeys, nodeChildKeys);
            RelationChildKeys(childKeys);
        }

        public Relation(
            ISleeve origin,
            ISleeve node,
            ISleeve target,
            string[] parentKeys,
            string[] nodeParentKeys,
            string[] nodeChildKeys,
            string[] childKeys
        ) : this(origin, node, target)
        {
            RelationParentKeys(parentKeys);
            RelationNodeKeys(nodeParentKeys, nodeParentKeys);
            RelationChildKeys(childKeys);
        }

        public IUnique Empty => Uscn.Empty;

        public string Name { get; set; }

        public RelationMember Origin { get; set; }

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

        public RelationNode Node { get; set; }

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

        public RelationMember Target { get; set; }

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

        public Relation SetRelation(ISleeve origin, ISleeve target, IRubrics parentKeys, IRubrics childKeys)
        {
            RelationPair(origin, target);
            RelationParentKeys(parentKeys);
            RelationChildKeys(childKeys);
            return this;
        }

        public Relation SetRelation(
            ISleeve origin,
            ISleeve target,
            string[] parentKeynames,
            string[] childKeynames
        )
        {
            RelationPair(origin, target);
            RelationParentKeys(parentKeynames);
            RelationChildKeys(childKeynames);
            return this;
        }

        public Relation RelationPair(ISleeve origin, ISleeve target)
        {
            Name = origin.GetType().Name + "To" + target.GetType().Name;

            UniqueKey = Name.UniqueKey64();
            UniqueType = Name.UniqueKey32();

            Origin = new RelationMember(origin, this, RelationSite.Origin);
            Target = new RelationMember(target, this, RelationSite.Target);

            return Relationer.Map.Put(this).Value;
        }

        public Relation RelationTrio(ISleeve origin, ISleeve node, ISleeve target)
        {
            Name = origin.GetType().Name + "To" + target.GetType().Name;

            UniqueKey = Name.UniqueKey64();
            UniqueType = Name.UniqueKey32();

            Origin = new RelationMember(origin, this, RelationSite.Origin);
            Node = new RelationNode(node, this);
            Target = new RelationMember(target, this, RelationSite.Target);

            return Relationer.Map.Put(this).Value;
        }

        public void RelationParentKeys(IRubrics keyRubrics)
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

        public void RelationNodeKeys(IRubrics originKeyRubric, IRubrics targetKeyRubric)
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

        public void RelationChildKeys(IRubrics keyRubrics)
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

        public void RelationChildKeys(string[] keyRubricNames)
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

        public void RelationNodeKeys(string[] originKeyRubricNames, string[] targetKeyRubricNames)
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

        public void RelationParentKeys(string[] keyRubricNames)
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
