using System.Runtime.Serialization;
using UltimatR;

namespace Undersoft.AEP
{
    [DataContract]
    public class Configuration : Identifiable
    {
        [DataMember(Order = 11)]
        public long UniverseId { get; set; }

        [DataMember(Order = 12)]
        public long AllocSetId { get; set; }

        [DataMember(Order = 13)]
        public long AssetId { get; set; }
    }
}