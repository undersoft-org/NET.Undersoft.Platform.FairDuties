using RadicalR;
using System.Runtime.Serialization;

namespace Undersoft.AEP.Raw
{
    [DataContract]
    public class Usage : Identifiable, IUsage
    {
        [DataMember(Order = 11)]
        public long CurrentId { get; set; }
    }
}
