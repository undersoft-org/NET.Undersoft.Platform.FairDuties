using RadicalR;

namespace Undersoft.ODP.Api
{
    public class Personal : Dto
    {
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public DateTime Birthdate { get; set; }

        public int Age { get; set; }

        public virtual DtoSet<Attribute> Attributes { get; set; }

        public virtual DtoSet<Contact> Contacts { get; set; }

        public virtual DtoSet<Device> Devices { get; set; }
    }
}