using RadicalR;
using System.Runtime.Serialization;
using System.Uniques;

namespace Undersoft.AEP.Raw
{
    [DataContract]
    public class Asset : UniqueObject
    {
        [DataMember(Order = 11)]
        public string Name { get; set; }

        [DataMember(Order = 12)]
        public double Value { get; set; }
    }
}
