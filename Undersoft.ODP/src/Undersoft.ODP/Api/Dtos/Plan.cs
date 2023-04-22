using RadicalR;

namespace Undersoft.ODP.Api
{
    public class Plan : Dto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TimeSpan Interval { get; set; }      

        public virtual DtoSet<BasicOrganization> Organizations { get; set; }

        public virtual DtoSet<BasicUser> Users { get; set; }

        public virtual DtoSet<BasicTeam> Teams { get; set; }

        public virtual DtoSet<ShiftType> ShiftTypes { get; set; }

        public virtual DtoSet<Shift> Shifts { get; set; }
    }
}
