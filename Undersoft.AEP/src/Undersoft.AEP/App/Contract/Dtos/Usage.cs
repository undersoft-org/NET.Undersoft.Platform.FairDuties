using System.Runtime.Serialization;
using System.Series;

namespace Undersoft.AEP.Api
{
    [DataContract]
    public class Usage : Raw.Usage, IDto
    {
        [DataMember(Order = 12)]
        public Source Source { get; set; }
    }
}
