using System.Runtime.Serialization;
using System.Uniques;

namespace Undersoft.AEP.Raw
{
    [DataContract]
    public class Setup : UniqueObject
    {
        [DataMember(Order = 11)]
        public long VertexId { get; set; }

        [DataMember(Order = 12)]
        public long UsageSetId { get; set; }
    }
}