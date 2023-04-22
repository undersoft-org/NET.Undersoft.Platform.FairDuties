using RadicalR;

namespace Undersoft.ODP.Api
{
    public class BasicTeam : Dto
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public long? LeadershipId { get; set; }

        public long? ConfigurationId { get; set; }
    }
}