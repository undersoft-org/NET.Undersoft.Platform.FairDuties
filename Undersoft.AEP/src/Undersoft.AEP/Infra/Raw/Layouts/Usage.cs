using System.Runtime.Serialization;
using System.Uniques;

namespace Undersoft.AEP.Raw
{
    [DataContract]
    public class Usage : UniqueObject, IUsage
    {
        [DataMember(Order = 11)]
        public long CurrentId { get; set; }
    }
}
