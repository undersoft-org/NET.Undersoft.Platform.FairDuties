using System.Runtime.Serialization;
using UltimatR;

namespace Undersoft.AEP
{
    [DataContract]
    public class Universe : Identifiable
    {
        [DataMember(Order = 11)]
        public long ConfigurationId { get; set; }

        [DataMember(Order = 12)]
        public float LastResourceOrdinal { get; set; }

        [DataMember(Order = 13)]
        public float LastClaimOrdinal { get; set; }

        [DataMember(Order = 14)]
        public float LastRateOrdinal { get; set; }
    }
}
