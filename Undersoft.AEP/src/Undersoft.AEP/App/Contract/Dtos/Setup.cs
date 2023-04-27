using System.Runtime.Serialization;
using System.Series;

namespace Undersoft.AEP.Api
{
    [DataContract]
    public class Setup : Raw.Setup, IDto
    {
        [DataMember(Order = 14)]
        public virtual Listing<Raw.UsageOption> UsageOptions { get; set; }
    }
}