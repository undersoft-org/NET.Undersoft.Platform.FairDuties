using UltimatR;

namespace Undersoft.ODP.Api
{
    public class Team : Dto
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public long? LeadershipId { get; set; }
        public virtual BasicUser Leadership { get; set; }

        public long? ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }

        public virtual DtoSet<BasicUser> Users { get; set; }

        public virtual DtoSet<Attribute> Attributes { get; set; }

        public long? ConfigurationId { get; set; }
        public virtual Configuration Configuration { get; set; }

        public virtual DtoSet<Schedule> ScheduleViews { get; set; }

        public virtual DtoSet<ShiftRequest> ShiftRequests { get; set; }
    }
}