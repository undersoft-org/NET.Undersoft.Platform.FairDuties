using Undersoft.AEP;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using RadicalR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Setting : Entity, IAllocOption
    {
        public string Name { get; set; }

        public string Data { get; set; }

        public string TypeName { get; set; }

        [NotMapped]
        public object Value { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Configuration> Configurations { get; set; }
    }
}