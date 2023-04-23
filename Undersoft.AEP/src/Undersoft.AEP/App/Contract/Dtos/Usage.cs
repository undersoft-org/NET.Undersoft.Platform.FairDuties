using System.Runtime.Serialization;

namespace Undersoft.AEP.Api
{
    [DataContract]
    public class Usage : Raw.Usage
    {
        [DataMember(Order = 12)]
        public Source Source { get; set; }
    }
}
