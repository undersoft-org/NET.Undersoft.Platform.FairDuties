using System.Runtime.Serialization;

namespace Undersoft.AEP
{
    [DataContract]
    public class AllocDto : Alloc
    {
        [DataMember(Order = 12)]
        public Source Source { get; set; }
    }
}
