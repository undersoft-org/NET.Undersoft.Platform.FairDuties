using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using UltimatR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Plan : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public virtual DboToSet<Organization> Organizations { get; set; }

        public virtual DboToSet<User> Users { get; set; }

        public virtual DboToSet<Team> Teams { get; set; }

        public virtual DboToSet<ShiftType> ShiftTypes { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        public DboSet<Shift> Shifts { get; set; }
    }
}
