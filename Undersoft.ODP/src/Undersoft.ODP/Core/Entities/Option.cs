using RadicalR;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Undersoft.AEP.Core;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Option : Entity, IUsageOption
    {
        public string Name { get; set; }

        public string Data { get; set; }

        public string TypeName { get; set; }

        [NotMapped]
        public object Value { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Setup> Setups { get; set; }
    }
}