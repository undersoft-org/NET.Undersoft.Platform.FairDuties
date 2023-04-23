using RadicalR;

namespace Undersoft.ODP.Domain
{
    public class Request : Entity
    {
        public string Reason { get; set; }

        public string Description { get; set; }

        public RequestType Type { get; set; }

        public RequestStatus Status { get; set; }

        public long? GroupId { get; set; }
        public virtual Group Group { get; set; }

        public long? MemberId { get; set; }
        public virtual Member Member { get; set; }

        public virtual EntitySet<Duty> Duties { get; set; }
    }
}
