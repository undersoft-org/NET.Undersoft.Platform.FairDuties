using System.Runtime.Serialization;
using UltimatR;

namespace Undersoft.AEP
{
    [DataContract]
    public class AllocType : Identifiable
    {
        [DataMember(Order = 11)]
        public string Name { get; set; }

        [DataMember(Order = 12)]
        public float Size { get; set; }
    }
}
