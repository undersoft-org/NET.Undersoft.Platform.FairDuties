using RadicalR;

namespace Undersoft.ODP.Api
{
    public class Vector : Dto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool IsView { get; set; }

        public long? GroupId { get; set; }

        public virtual DtoSet<Duty> Duties { get; set; }
    }
}
