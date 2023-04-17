using UltimatR;

namespace Undersoft.ODP.Api
{
    public class ShiftTypeDto : Dto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public float Size { get; set; }

        public virtual DtoSet<ShiftTypeDto> DependentOn { get; set; }

        public virtual DtoSet<ShiftTypeDto> RelatedTo { get; set; }

        public virtual DtoSet<ShiftTypeDto> OptionalTo { get; set; }
    }
}
