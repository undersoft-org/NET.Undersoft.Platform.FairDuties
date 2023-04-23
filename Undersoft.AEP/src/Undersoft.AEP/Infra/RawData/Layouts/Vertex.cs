using RadicalR;
using System.Runtime.Serialization;

namespace Undersoft.AEP.Raw
{
    [DataContract]
    public class Vertex : Identifiable
    {
        [DataMember(Order = 11)]
        public long SetupId { get; set; }

        [DataMember(Order = 12)]
        public int LastResourceOrdinal { get; set; }

        [DataMember(Order = 13)]
        public int LastExploitanceOrdinal { get; set; }

        [DataMember(Order = 14)]
        public int LastEstimateOrdinal { get; set; }
    }
}
