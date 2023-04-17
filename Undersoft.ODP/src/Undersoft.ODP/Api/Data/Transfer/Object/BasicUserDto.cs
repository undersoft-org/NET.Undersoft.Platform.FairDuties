using UltimatR;

namespace Undersoft.ODP.Api
{
    public class BasicUserDto : Dto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public long? ConfigurationId { get; set; }
    }
}