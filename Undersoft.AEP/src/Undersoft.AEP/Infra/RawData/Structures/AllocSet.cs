using System.Runtime.Serialization;
using UltimatR;

namespace Undersoft.AEP
{
    [DataContract]
    public class AllocSet : Identifiable
    {
        [DataMember(Order = 11)]
        public float FrameCapacity { get; set; }

        [DataMember(Order = 12)]
        public float BlockCapacity { get; set; }

        [DataMember(Order = 13)]
        public int FrameSize { get; set; }

        [DataMember(Order = 14)]
        public int BlockSize { get; set; }

        [DataMember(Order = 15)]
        public float FrameSeed { get; set; }

        [DataMember(Order = 16)]
        public long SequenceId { get; set; }

        [DataMember(Order = 17)]
        public long UniverseId { get; set; }

        [DataMember(Order = 18)]
        public long ConfigurationId { get; set; }

        [DataMember(Order = 19)]
        public int LastRateOrdinal { get; set; }

        [DataMember(Order = 20)]
        public int LastResourceOrdinal { get; set; }

        [DataMember(Order = 21)]
        public int LastClaimOrdinal { get; set; }
    }
}
