using UltimatR;

namespace Undersoft.ODP.Api
{
    public class UserDto : Dto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DtoSet<UserRoleDto> Roles { get; set; }

        public long? PersonalId { get; set; }
        public PersonalDto Personal { get; set; }

        public long? ConfigurationId { get; set; }
        public ConfigurationDto Configuration { get; set; }

        public DtoSet<IdentifierDto<UserDto>> Identifiers { get; set; }

        public virtual DtoSet<AttributeDto> Attributes { get; set; }

        public virtual DtoSet<BasicOrganizationDto> Organizations { get; set; }

        public virtual DtoSet<BasicTeamDto> Teams { get; set; }

        public virtual DtoSet<ShiftTypeDto> ShiftTypes { get; set; }

        public virtual DtoSet<ShiftRateDto> ShiftRates { get; set; }

        public virtual DtoSet<ShiftDto> Shifts { get; set; }

        public virtual DtoSet<ShiftRequestDto> ShiftRequests { get; set; }
    }
}