using UltimatR;

namespace Undersoft.ODP.Api
{
    using Domain;

    public class ShiftDto : Dto
    {
        public long? OrganizationId { get; set; }

        public long? TeamId { get; set; }

        public long? UserId { get; set; }

        public long? ShiftTypeId { get; set; }

        public long? ScheduleId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public virtual DtoSet<ShiftRequestDto> Requests { get; set; }

        public WorkMode WorkMode { get; set; }

        public ShiftStatus Status { get; set; }

        public bool HasRequests { get; set; }

        public bool IsRequested { get; set; }
    }
}
