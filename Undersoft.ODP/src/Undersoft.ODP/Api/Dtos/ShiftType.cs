using RadicalR;

namespace Undersoft.ODP.Api
{
    public class ShiftType : Dto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public float Size { get; set; }

        public virtual DtoSet<ShiftType> DependentOn { get; set; }

        public virtual DtoSet<ShiftType> RelatedTo { get; set; }

        public virtual DtoSet<ShiftType> OptionalTo { get; set; }
    }
}
