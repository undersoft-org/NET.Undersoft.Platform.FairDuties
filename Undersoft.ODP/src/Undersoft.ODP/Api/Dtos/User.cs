using RadicalR;

namespace Undersoft.ODP.Api
{
    public class User : Dto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DtoSet<UserRole> Roles { get; set; }

        public long? PersonalId { get; set; }
        public Personal Personal { get; set; }

        public long? ConfigurationId { get; set; }
        public Configuration Configuration { get; set; }

        public DtoSet<IdentifierDto<User>> Identifiers { get; set; }

        public virtual DtoSet<Attribute> Attributes { get; set; }

        public virtual DtoSet<BasicOrganization> Organizations { get; set; }

        public virtual DtoSet<BasicTeam> Teams { get; set; }

        public virtual DtoSet<ShiftType> ShiftTypes { get; set; }

        public virtual DtoSet<ShiftRate> ShiftRates { get; set; }

        public virtual DtoSet<Shift> Shifts { get; set; }

        public virtual DtoSet<ShiftRequest> ShiftRequests { get; set; }
    }
}