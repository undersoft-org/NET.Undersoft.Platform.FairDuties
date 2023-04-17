using System.Runtime.Serialization;
using UltimatR;

namespace Undersoft.AEP
{
    [DataContract]
    public class Asset : Identifiable
    {
        [DataMember(Order = 11)]
        public long ConfigurationId { get; set; }

        [DataMember(Order = 12)]
        public int LastRateOrdinal { get; set; }

        [DataMember(Order = 13)]
        public int LastResourceOrdinal { get; set; }
    }
}
