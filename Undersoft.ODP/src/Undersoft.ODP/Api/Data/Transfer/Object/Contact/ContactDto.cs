using Undersoft.ODP.Domain;
using UltimatR;

namespace Undersoft.ODP.Api
{
    public class ContactDto : Dto
    {
        public string Name { get; set; }

        public ContactType Type { get; set; }

        public string Email { get; set; }

        public PhoneType PhoneType { get; set; }

        public string PhoneNumber { get; set; }

        public string Notices { get; set; }

        public virtual DtoSet<AddressDto> Addresses { get; set; }
    }
}
