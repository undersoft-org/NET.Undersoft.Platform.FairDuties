﻿using System.Runtime.Serialization;
using UltimatR;

namespace Undersoft.AEP
{
    [DataContract]
    public class Alloc : Identifiable
    {
        [DataMember(Order = 11)]
        public long CurrentId { get; set; }
    }
}