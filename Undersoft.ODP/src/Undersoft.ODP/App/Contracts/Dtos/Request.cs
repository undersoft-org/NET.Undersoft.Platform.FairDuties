using RadicalR;

namespace Undersoft.ODP.Api
{
    using Domain;

    public class Request : Dto
    {
        public string Reason { get; set; }

        public string Description { get; set; }

        public RequestType Type { get; set; }

        public RequestStatus Status { get; set; }

        public long? GroupId { get; set; }

        public long? MemberId { get; set; }
    }
}
