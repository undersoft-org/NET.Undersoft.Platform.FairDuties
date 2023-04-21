using UltimatR;

namespace Undersoft.ODP.Api
{
    using Domain;

    public class ShiftRequest : Dto
    {
        public string Reason { get; set; }

        public string Description { get; set; }

        public ShiftRequestType Type { get; set; }

        public ShiftRequestStatus Status { get; set; }

        public long? TeamId { get; set; }

        public long? UserId { get; set; }
    }
}
