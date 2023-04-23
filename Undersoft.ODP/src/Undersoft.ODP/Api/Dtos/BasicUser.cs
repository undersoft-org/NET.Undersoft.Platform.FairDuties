using System.Runtime.Serialization;
using RadicalR;

namespace Undersoft.ODP.Api
{
    [DataContract]
    public class BasicMember : Dto
    {
        [DataMember(Order = 0)]
        public string MemberName { get; set; }

        [DataMember(Order = 1)]
        public string Email { get; set; }

        [DataMember(Order = 2)]
        public string PhoneNumber { get; set; }

        [DataMember(Order = 3)]
        public long? SetupId { get; set; }
    }
}