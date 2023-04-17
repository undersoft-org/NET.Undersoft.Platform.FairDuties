using System.Instant;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using UltimatR;

namespace Undersoft.AEP
{
    public class Link<TSource, TTarget> : Link
    {
        public Link(string typeSuffix = "")
        {
            var sourceType = typeof(TSource);
            var targetType = typeof(TTarget);
            SourceName = sourceType.FullName;
            TargetName = targetType.FullName;
            Label = this.GetType().Name;
        }
    }

    [DataContract]
    public class Link : Identifiable, ILink
    {
        [DataMember(Order = 11)]
        [FigureAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        public string SourceName { get; set; }

        [DataMember(Order = 12)]
        [FigureAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        public string TargetName { get; set; }
    }
}
