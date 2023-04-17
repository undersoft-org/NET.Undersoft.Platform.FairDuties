using UltimatR;

namespace Undersoft.ODP.Api
{
    public class PlanDto : Dto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TimeSpan Interval { get; set; }      

        public virtual DtoSet<BasicOrganizationDto> Organizations { get; set; }

        public virtual DtoSet<BasicUserDto> Users { get; set; }

        public virtual DtoSet<BasicTeamDto> Teams { get; set; }

        public virtual DtoSet<ShiftTypeDto> ShiftTypes { get; set; }

        public virtual DtoSet<ShiftDto> Shifts { get; set; }
    }
}
