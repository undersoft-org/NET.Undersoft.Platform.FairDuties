using RadicalR;
using System.Runtime.Serialization;

namespace Undersoft.AEP.Raw
{
    [DataContract]
    public class Asset : Identifiable
    {
        [DataMember(Order = 11)]
        public string Name { get; set; }

        [DataMember(Order = 12)]
        public float Size { get; set; }
    }
}
