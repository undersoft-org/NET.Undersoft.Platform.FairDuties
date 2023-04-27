using System.Instant;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Uniques;

namespace Undersoft.AEP.Raw
{
    [DataContract]
    public class UsageOption : UniqueObject
    {
        [DataMember(Order = 11)]
        public long SetupId { get; set; }

        [DataMember(Order = 12)]
        [FigureAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        public string Name { get; set; }

        [DataMember(Order = 14)]
        [FigureAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        public string TypeName { get; set; }

        [DataMember(Order = 13)]
        [FigureAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
        public string Data { get; set; }
    }
}