using RadicalR;

namespace Undersoft.ODP.Api
{
    public class Member : Dto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DtoSet<Role> Roles { get; set; }

        public long? ProfileId { get; set; }
        public Profile Profile { get; set; }

        public long? SetupId { get; set; }
        public Setup Setup { get; set; }

        public DtoSet<IdentifierDto<Member>> Identifiers { get; set; }

        public virtual DtoSet<Property> Properties { get; set; }

        public virtual DtoSet<BasicUnion> Unions { get; set; }

        public virtual DtoSet<BasicGroup> Groups { get; set; }

        public virtual DtoSet<Asset> Assets { get; set; }

        public virtual DtoSet<Estimate> FrameRates { get; set; }

        public virtual DtoSet<Duty> Frames { get; set; }

        public virtual DtoSet<Request> Requests { get; set; }
    }
}