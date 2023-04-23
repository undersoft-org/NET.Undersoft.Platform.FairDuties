using RadicalR;
using System.Runtime.Serialization;

namespace Undersoft.AEP.Raw
{
    [DataContract]
    public class Source : Identifiable
    {
        [DataMember(Order = 11)]
        public long SetupId { get; set; }

        [DataMember(Order = 12)]
        public int LastEstimateOrdinal { get; set; }

        [DataMember(Order = 13)]
        public int LastResourceOrdinal { get; set; }
    }
}
