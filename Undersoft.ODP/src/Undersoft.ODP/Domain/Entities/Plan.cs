using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using RadicalR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Plan : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public virtual EntityOnSet<Organization> Organizations { get; set; }

        public virtual EntityOnSet<User> Users { get; set; }

        public virtual EntityOnSet<Team> Teams { get; set; }

        public virtual EntityOnSet<ShiftType> ShiftTypes { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        public EntitySet<Shift> Shifts { get; set; }
    }
}
