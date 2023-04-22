using Undersoft.ODP.Domain;
using RadicalR;

namespace Undersoft.ODP.Api
{
    public class Contact : Dto
    {
        public string Name { get; set; }

        public ContactType Type { get; set; }

        public string Email { get; set; }

        public PhoneType PhoneType { get; set; }

        public string PhoneNumber { get; set; }

        public string Notices { get; set; }

        public virtual DtoSet<Address> Addresses { get; set; }
    }
}
