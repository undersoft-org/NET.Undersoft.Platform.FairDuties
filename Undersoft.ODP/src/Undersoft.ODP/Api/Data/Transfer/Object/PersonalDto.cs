using UltimatR;

namespace Undersoft.ODP.Api
{
    public class PersonalDto : Dto
    {
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public DateTime Birthdate { get; set; }

        public int Age { get; set; }

        public virtual DtoSet<AttributeDto> Attributes { get; set; }

        public virtual DtoSet<ContactDto> Contacts { get; set; }

        public virtual DtoSet<DeviceDto> Devices { get; set; }
    }
}