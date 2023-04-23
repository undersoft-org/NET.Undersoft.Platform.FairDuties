using RadicalR;
using System.ComponentModel.DataAnnotations.Schema;

namespace Undersoft.ODP.Domain
{
    public class Vertex : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int StartBlock { get; set; }

        public int EndBlock { get; set; }

        public virtual EntityOnSets<Union>  Unions { get; set; }

        public virtual EntityOnSets<Member> Members { get; set; }

        public virtual EntityOnSets<Group>  Groups { get; set; }

        public virtual EntityOnSets<Asset>  Assets { get; set; }

        [NotMapped]
        public EntitySet<Duty> Duties { get; set; }
    }
}
