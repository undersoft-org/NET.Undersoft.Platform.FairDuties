using System.Runtime.Serialization;
using RadicalR;

namespace Undersoft.ODP.Api
{
    [DataContract]
    public class BasicUser : Dto
    {
        [DataMember(Order = 0)]
        public string UserName { get; set; }

        [DataMember(Order = 1)]
        public string Email { get; set; }

        [DataMember(Order = 2)]
        public string PhoneNumber { get; set; }

        [DataMember(Order = 3)]
        public long? ConfigurationId { get; set; }
    }
}