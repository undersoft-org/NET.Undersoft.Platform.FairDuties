using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using UltimatR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Attribute : Entity
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public virtual DboToSets<Attribute> RelatedFrom { get; set; }

        public virtual DboToSets<Attribute> RelatedTo { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboSet<User> Users { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboSet<Team> Teams { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboSet<ShiftType> ShiftTypes { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboSet<Organization> Organizations { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboSet<Configuration> Configurations { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboSet<Personal> Personals { get; set; }
    }
}