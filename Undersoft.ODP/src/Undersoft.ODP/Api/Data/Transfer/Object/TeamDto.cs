using UltimatR;

namespace Undersoft.ODP.Api
{
    public class TeamDto : Dto
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public long? LeadershipId { get; set; }
        public virtual BasicUserDto Leadership { get; set; }

        public long? ScheduleId { get; set; }
        public virtual ScheduleDto Schedule { get; set; }

        public virtual DtoSet<BasicUserDto> Users { get; set; }

        public virtual DtoSet<AttributeDto> Attributes { get; set; }

        public long? ConfigurationId { get; set; }
        public virtual ConfigurationDto Configuration { get; set; }

        public virtual DtoSet<ScheduleDto> ScheduleViews { get; set; }

        public virtual DtoSet<ShiftRequestDto> ShiftRequests { get; set; }
    }
}