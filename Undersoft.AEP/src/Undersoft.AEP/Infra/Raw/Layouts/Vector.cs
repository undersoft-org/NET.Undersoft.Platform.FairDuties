using System.Runtime.Serialization;
using System.Uniques;

namespace Undersoft.AEP.Raw
{
    [DataContract]
    public class Vector : UniqueObject
    {
        [DataMember(Order = 11)]
        public long UsageSetId { get; set; }

        [DataMember(Order = 12)]
        public int SectorOffset { get; set; }

        [DataMember(Order = 13)]
        public int SectorCount { get; set; }

        [DataMember(Order = 14)]
        public int BlockOffset { get; set; }

        [DataMember(Order = 15)]
        public int BlockCount { get; set; }
         
        [DataMember(Order = 16)]
        public int LastSectorId { get; set; }

        [DataMember(Order = 17)]
        public int LastBlockId { get; set; }

        [DataMember(Order = 18)]
        public int LastSocketId { get; set; }

        [DataMember(Order = 19)]
        public int LastUsageId { get; set; }

        [DataMember(Order = 20)]
        public int LastEstimateOrdinal { get; set; }

        [DataMember(Order = 21)]
        public float LastResourceOrdinal { get; set; }

        [DataMember(Order = 22)]
        public float LastLiabilityOrdinal { get; set; }

        [DataMember(Order = 23)]
        public int LastUsageOrdinal { get; set; }
    }
}
