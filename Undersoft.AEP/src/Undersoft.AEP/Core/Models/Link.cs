using System.Instant.Linking;
using System.Runtime.Serialization;
using System.Uniques;

namespace Undersoft.AEP.Core
{
    public class Link<TSource, TTarget> : Link
    {
        public Link(string suffix = null)
        {
            var sourceType = typeof(TSource);
            var targetType = typeof(TTarget);
            SourceType = sourceType.FullName;
            TargetType = targetType.FullName;
            Label = sourceType.Name + "To" + targetType.Name + suffix;
        }
    }

    [DataContract]
    public class Link : UniqueObject, ILink
    {
    }
}
