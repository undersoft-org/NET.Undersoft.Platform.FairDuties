using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using RadicalR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Profile : Entity
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
        public virtual Member User { get; set; }

        public virtual EntityOnSets<Property> Properties { get; set; }

        public virtual EntityOnSets<Contact> Contacts { get; set; }

        public virtual EntityOnSets<Client> Devices { get; set; }
    }
}