using System.Runtime.Serialization;
using RadicalR;

namespace Undersoft.AEP
{
    [DataContract]
    public class AllocSetDto : AllocSet
    {
        [DataMember(Order = 19)]
        public virtual Universe Universe { get; set; }

        [DataMember(Order = 20)]
        public virtual DtoSet<Link<Asset, AssetDto>> AssetLinks { get; set; }

        [DataMember(Order = 21)]
        public virtual DtoSet<Link<AllocType, AllocTypeDto>> AllocTypeLinks { get; set; }

        [DataMember(Order = 22)]
        public virtual DtoSet<AllocRateDto> AllocRates { get; set; }

        [DataMember(Order = 23)]
        public virtual ConfigurationDto Configuration { get; set; }
    }
}
