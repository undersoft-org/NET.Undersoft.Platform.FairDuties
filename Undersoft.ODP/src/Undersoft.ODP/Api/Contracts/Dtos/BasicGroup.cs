using RadicalR;

namespace Undersoft.ODP.Api
{
    public class BasicGroup : Dto
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public long? LeadershipId { get; set; }

        public long? SetupId { get; set; }
    }
}