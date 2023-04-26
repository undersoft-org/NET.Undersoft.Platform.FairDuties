using RadicalR;
using System.Runtime.Serialization;
using Undersoft.AEP.Core;

namespace Undersoft.AEP.Raw
{
    [DataContract]
    public class Duty : Identifiable, IUsability
    {
        [DataMember(Order = 11)]
        public long VertexId { get; }

        [DataMember(Order = 13)]
        public long UsageSetId { get; }

        [DataMember(Order = 14)]
        public long AssetId { get; set; }

        [DataMember(Order = 15)]
        public long EstimateId { get; set; }

        [DataMember(Order = 16)]
        public long VectorId { get; set; }

        [DataMember(Order = 17)]
        public int SectorOffset { get; set; }

        [DataMember(Order = 18)]
        public int BlockOffset { get; set; }

        [DataMember(Order = 19)]
        public long SectorId { get; set; }

        [DataMember(Order = 20)]
        public long BlockId { get; set; }

        [DataMember(Order = 21)]
        public long SocketId { get; set; }

        [DataMember(Order = 23)]
        public long ResourceId { get; set; }

        [DataMember(Order = 24)]
        public long UsageId { get; set; }
    }
}
