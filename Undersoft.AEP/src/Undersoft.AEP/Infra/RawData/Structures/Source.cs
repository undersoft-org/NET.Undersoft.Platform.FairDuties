using System.Runtime.Serialization;
using UltimatR;

namespace Undersoft.AEP
{
    [DataContract]
    public class Source : Identifiable, IAllocable
    {
        [DataMember(Order = 11)]
        public long UniverseId { get; }

        [DataMember(Order = 12)]
        public long AssetId { get; set; }

        [DataMember(Order = 13)]
        public long AllocSetId { get; }

        [DataMember(Order = 14)]
        public long AllocTypeId { get; set; }

        [DataMember(Order = 15)]
        public long AllocRateId { get; set; }

        [DataMember(Order = 16)]
        public long SequenceId { get; set; }

        [DataMember(Order = 17)]
        public int FrameOffset { get; set; }

        [DataMember(Order = 18)]
        public int BlockOffset { get; set; }

        [DataMember(Order = 19)]
        public long BlockId { get; set; }

        [DataMember(Order = 20)]
        public long FrameId { get; set; }

        [DataMember(Order = 21)]
        public long SlotId { get; set; }

        [DataMember(Order = 22)]
        public long AllocId { get; set; }

        [DataMember(Order = 23)]
        public long ResourceId { get; set; }

        [DataMember(Order = 24)]
        public long ClaimId { get; set; }
    }
}
