using System.ComponentModel.DataAnnotations.Schema;

namespace UltimatR
{

    public class DboRelation<TLeft, TRight> : Entity, IDboRelation<TLeft, TRight> where TLeft : class, IIdentifiable where TRight : class, IIdentifiable
    {
        public virtual long RightEntityId { get; set; }

        public virtual TRight RightEntity { get; set; }

        public virtual long LeftEntityId { get; set; }

        public virtual TLeft LeftEntity { get; set; }

        [NotMapped] public long LeftId { get => LeftEntityId; set => LeftEntityId = value; }
        [NotMapped] public long RightId { get => RightEntityId; set => RightEntityId = value; }

        [NotMapped] public long FromId { get => LeftEntityId; set => LeftEntityId = value; }
        [NotMapped] public long ToId { get => RightEntityId; set => RightEntityId = value; }
    }
}