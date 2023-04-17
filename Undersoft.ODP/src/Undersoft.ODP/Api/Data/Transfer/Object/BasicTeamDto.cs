using UltimatR;

namespace Undersoft.ODP.Api
{
    public class BasicTeamDto : Dto
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public long? LeadershipId { get; set; }

        public long? ConfigurationId { get; set; }
    }
}