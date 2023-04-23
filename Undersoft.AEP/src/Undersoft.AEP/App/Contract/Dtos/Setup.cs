using RadicalR;
using System.Runtime.Serialization;

namespace Undersoft.AEP.Api
{
    [DataContract]
    public class Setup : Raw.Setup
    {
        [DataMember(Order = 14)]
        public virtual DtoSet<Raw.UsageOption> UsageOptions { get; set; }
    }
}