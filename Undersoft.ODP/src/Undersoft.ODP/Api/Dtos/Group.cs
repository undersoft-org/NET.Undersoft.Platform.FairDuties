using RadicalR;

namespace Undersoft.ODP.Api
{
    public class Group : Dto
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public long? LeadershipId { get; set; }
        public virtual BasicUser Leadership { get; set; }

        public long? ScheduleId { get; set; }
        public virtual Vector Schedule { get; set; }

        public virtual DtoSet<BasicUser> Users { get; set; }

        public virtual DtoSet<Property> Properties { get; set; }

        public long? SetupId { get; set; }
        public virtual Setup Setup { get; set; }

        public virtual DtoSet<Vector> ScheduleViews { get; set; }

        public virtual DtoSet<Request> Requests { get; set; }
    }
}