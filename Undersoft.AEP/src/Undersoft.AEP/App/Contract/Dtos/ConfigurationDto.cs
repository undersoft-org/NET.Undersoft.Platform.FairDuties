using System.Runtime.Serialization;
using UltimatR;

namespace Undersoft.AEP
{
    [DataContract]
    public class ConfigurationDto : Configuration
    {
        [DataMember(Order = 14)]
        public virtual DtoSet<AllocOption> AllocOptions { get; set; }
    }
}