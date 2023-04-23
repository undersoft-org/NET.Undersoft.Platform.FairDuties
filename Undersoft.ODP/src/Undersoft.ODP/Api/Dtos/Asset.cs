using RadicalR;

namespace Undersoft.ODP.Api
{
    public class Asset : Dto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public float Size { get; set; }

        public virtual DtoSet<Asset> DependentOn { get; set; }

        public virtual DtoSet<Asset> RelatedTo { get; set; }

        public virtual DtoSet<Asset> OptionalTo { get; set; }
    }
}
