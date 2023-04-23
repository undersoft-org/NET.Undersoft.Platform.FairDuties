using RadicalR;

namespace Undersoft.ODP.Api
{
    public class Vertex : Dto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TimeSpan Interval { get; set; }

        public virtual DtoSet<BasicUnion> Unions { get; set; }

        public virtual DtoSet<BasicUser> Users { get; set; }

        public virtual DtoSet<BasicGroup> Groups { get; set; }

        public virtual DtoSet<Asset> Assets { get; set; }

        public virtual DtoSet<Duty> Frames { get; set; }
    }
}
