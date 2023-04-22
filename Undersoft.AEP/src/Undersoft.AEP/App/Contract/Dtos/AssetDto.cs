using System.Runtime.Serialization;
using RadicalR;

namespace Undersoft.AEP
{
    [DataContract]
    public class AssetDto : Asset
    {
        [DataMember(Order = 12)]
        public virtual DtoSet<AllocRateDto> AllocRates { get; set; }

        [DataMember(Order = 13)]
        public virtual DtoSet<Link<AllocType, AllocTypeDto>> AllocTypeLinks { get; set; }

        [DataMember(Order = 14)]
        public virtual ConfigurationDto Configuration { get; set; }
    }
}
