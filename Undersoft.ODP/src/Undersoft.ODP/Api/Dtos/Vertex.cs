using RadicalR;

namespace Undersoft.ODP.Api
{
    public class Vertex : Dto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int StartBlock { get; set; }

        public int EndBlock { get; set; }

        public virtual DtoSet<BasicUnion> Unions { get; set; }

        public virtual DtoSet<BasicMember> Members { get; set; }

        public virtual DtoSet<BasicGroup> Groups { get; set; }

        public virtual DtoSet<Asset> Assets { get; set; }

        public virtual DtoSet<Duty> Duties { get; set; }
    }
}
