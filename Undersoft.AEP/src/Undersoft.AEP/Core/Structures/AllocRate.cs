using System.Runtime.Serialization;
using UltimatR;

namespace Undersoft.AEP
{
    [DataContract]
    public class AllocRate : Identifiable
    {
        [DataMember(Order = 11)]
        public double Rank { get; set; }

        [DataMember(Order = 12)]
        public double Checksum { get; set; }

        [DataMember(Order = 13)]
        public double Quantity { get; set; }

        [DataMember(Order = 14)]
        public double Rate { get; set; }

        [DataMember(Order = 15)]
        public double Value { get; set; }

        [DataMember(Order = 16)]
        public double Total { get; set; }

        [DataMember(Order = 17)]
        public bool DependentByAny { get; set; }

        [DataMember(Order = 18)]
        public bool OptionalFromAny { get; set; }

        [DataMember(Order = 19)]
        public long AllocSetId { get; set; }

        [DataMember(Order = 20)]
        public long AssetId { get; set; }

        [DataMember(Order = 21)]
        public long AllocTypeId { get; }
    }
}
