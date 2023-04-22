using System.Runtime.Serialization;
using RadicalR;

namespace Undersoft.AEP
{
    [DataContract]
    public class Sequence : Identifiable
    {
        [DataMember(Order = 11)]
        public long AllocSetId { get; set; }

        [DataMember(Order = 12)]
        public int FrameOffset { get; set; }

        [DataMember(Order = 13)]
        public int FrameCount { get; set; }

        [DataMember(Order = 14)]
        public int BlockOffset { get; set; }

        [DataMember(Order = 15)]
        public int BlockCount { get; set; }

        [DataMember(Order = 16)]
        public int LastFrameId
        {
            get; set;
        }

        [DataMember(Order = 17)]
        public int LastBlockId { get; set; }

        [DataMember(Order = 18)]
        public int LastSlotId
        {
            get; set;
        }

        [DataMember(Order = 19)]
        public int LastAllocId
        {
            get; set;
        }

        [DataMember(Order = 20)]
        public int LastRateOrdinal { get; set; }

        [DataMember(Order = 21)]
        public float LastResourceOrdinal { get; set; }

        [DataMember(Order = 22)]
        public float LastClaimOrdinal { get; set; }

        [DataMember(Order = 23)]
        public int LastAllocOrdinal { get; set; }
    }
}
