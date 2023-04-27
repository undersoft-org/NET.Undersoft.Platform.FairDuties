using System.Runtime.Serialization;
using System.Uniques;

namespace Undersoft.AEP.Raw
{
    [DataContract]
    public class Vertex : UniqueObject
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
