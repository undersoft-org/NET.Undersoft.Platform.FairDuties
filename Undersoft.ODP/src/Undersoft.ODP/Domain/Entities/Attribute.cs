using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using RadicalR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Attribute : Entity
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public virtual EntityOnSets<Attribute> RelatedFrom { get; set; }

        public virtual EntityOnSets<Attribute> RelatedTo { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntitySet<User> Users { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntitySet<Team> Teams { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntitySet<ShiftType> ShiftTypes { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntitySet<Organization> Organizations { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntitySet<Configuration> Configurations { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntitySet<Personal> Personals { get; set; }
    }
}