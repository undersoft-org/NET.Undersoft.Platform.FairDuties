using RadicalR;

namespace Undersoft.ODP.Api
{
    public class Profile : Dto
    {
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public DateTime Birthdate { get; set; }

        public int Age { get; set; }

        public virtual DtoSet<Property> Properties { get; set; }

        public virtual DtoSet<Locale> Contacts { get; set; }

        public virtual DtoSet<Client> Devices { get; set; }
    }
}