﻿using RadicalR;
using System.Runtime.Serialization;
using System.Uniques;

namespace Undersoft.AEP.Raw
{
    [DataContract]
    public class Source : UniqueObject
    {
        [DataMember(Order = 11)]
        public long SetupId { get; set; }

        [DataMember(Order = 12)]
        public int LastEstimateOrdinal { get; set; }

        [DataMember(Order = 13)]
        public int LastResourceOrdinal { get; set; }
    }
}
