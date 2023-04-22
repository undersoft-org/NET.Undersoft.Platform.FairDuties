using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using RadicalR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Personal : Entity
    {
        public string Title { get; set; }

        public string Profession { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public DateTime Birthdate { get; set; }

        public int Age { get; set; }

        public long? UserId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual User User { get; set; }

        public virtual EntityOnSets<Attribute> Attributes { get; set; }

        public virtual EntityOnSets<Contact> Contacts { get; set; }

        public virtual EntityOnSets<Device> Devices { get; set; }
    }
}