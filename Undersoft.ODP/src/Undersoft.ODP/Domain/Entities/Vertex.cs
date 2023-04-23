using RadicalR;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Vertex : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int StartBlock { get; set; }

        public int EndBlock { get; set; }

        public virtual EntitySet<Union> Unions { get; set; }

        public virtual EntitySet<Member> Users { get; set; }

        public virtual EntitySet<Group> Groups { get; set; }

        public virtual EntitySet<Asset> Assets { get; set; }

        [NotMapped]
        public EntitySet<Duty> Duties { get; set; }
    }
}
