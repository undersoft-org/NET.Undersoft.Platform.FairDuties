using RadicalR;
using System.Runtime.Serialization;

namespace Undersoft.AEP.Raw
{
    [DataContract]
    public class Setup : Identifiable
    {
        [DataMember(Order = 11)]
        public long VertexId { get; set; }

        [DataMember(Order = 12)]
        public long UsageSetId { get; set; }
    }
}