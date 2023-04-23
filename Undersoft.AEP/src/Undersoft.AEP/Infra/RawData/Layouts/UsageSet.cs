using RadicalR;
using System.Runtime.Serialization;

namespace Undersoft.AEP.Raw
{
    [DataContract]
    public class UsageSet : Identifiable
    {
        [DataMember(Order = 11)]
        public float SectorCapacity { get; set; }

        [DataMember(Order = 12)]
        public float BlockCapacity { get; set; }

        [DataMember(Order = 13)]
        public int BlockSize { get; set; }

        [DataMember(Order = 14)]
        public int SectorSize { get; set; }

        [DataMember(Order = 15)]
        public float BlockSeed { get; set; }

        [DataMember(Order = 16)]
        public long VectorId { get; set; }

        [DataMember(Order = 17)]
        public long VertexId { get; set; }

        [DataMember(Order = 18)]
        public long SetupId { get; set; }

        [DataMember(Order = 19)]
        public int LastEstimateOrdinal { get; set; }

        [DataMember(Order = 20)]
        public int LastResourceOrdinal { get; set; }

        [DataMember(Order = 21)]
        public int LastLiabilityOrdinal { get; set; }
    }
}
