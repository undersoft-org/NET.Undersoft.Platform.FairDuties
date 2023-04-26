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

        public virtual EntitySet<Member> Members { get; set; }

        public virtual EntitySet<Group> Groups { get; set; }

        public virtual EntitySet<Asset> Assets { get; set; }

        public virtual EntitySet<Union> Unions { get; set; }

        public virtual EntitySet<Setup> Setups { get; set; }

        public virtual EntitySet<Profile> Profiles { get; set; }
    }
}