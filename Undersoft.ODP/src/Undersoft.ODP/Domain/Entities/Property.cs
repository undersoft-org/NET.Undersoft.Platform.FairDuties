using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using RadicalR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Property : Entity
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public virtual EntityOnSets<Property> RelatedFrom { get; set; }

        public virtual EntityOnSets<Property> RelatedTo { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntitySet<Member> Members { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntitySet<Group> Groups { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntitySet<Asset> Assets { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntitySet<Union> Unions { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntitySet<Setup> Setups { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntitySet<Profile> Profiles { get; set; }
    }
}