using RadicalR;

namespace Undersoft.ODP.Api
{
    using Domain;

    public class Duty : Dto
    {
        public long? UnionId { get; set; }

        public long? GroupId { get; set; }

        public long? MemberId { get; set; }

        public long? AssetId { get; set; }

        public long? VectorId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public virtual DtoSet<Request> Requests { get; set; }

        public DutyMode Mode { get; set; }

        public DutyStatus Status { get; set; }

        public bool HasRequests { get; set; }

        public bool IsRequested { get; set; }
    }
}
