﻿using RadicalR;
using System.Instant.Linking;
using System.Runtime.Serialization;

namespace Undersoft.AEP.Raw
{
    public class Link<TSource, TTarget> : Link
    {
        public Link(string typeSuffix = "")
        {
            var sourceType = typeof(TSource);
            var targetType = typeof(TTarget);
            SourceType = sourceType.FullName;
            SourceType = targetType.FullName;
            Label = this.GetType().FullName;
        }
    }

    [DataContract]
    public class Link : Identifiable, ILink
    {
    }
}