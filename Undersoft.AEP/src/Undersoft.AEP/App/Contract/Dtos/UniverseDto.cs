using System.Runtime.Serialization;
using RadicalR;

namespace Undersoft.AEP
{
    [DataContract]
    public class UniverseDto : Universe
    {
        [DataMember(Order = 12)]
        public virtual string Name { get; set; }

        [DataMember(Order = 13)]
        public virtual DtoSet<AllocSetDto> AllocSets { get; set; }

        [DataMember(Order = 14)]
        public virtual DtoSet<AllocTypeDto> AllocTypes { get; set; }

        [DataMember(Order = 15)]
        public virtual DtoSet<AssetDto> Assets { get; set; }

        [DataMember(Order = 16)]
        public virtual ConfigurationDto Configuration { get; set; }
    }
}
