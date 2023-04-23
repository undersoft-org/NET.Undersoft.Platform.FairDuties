using Microsoft.OData.Client;
using RadicalR;
using System.Runtime.Serialization;
using System.Series;
using System.Text.Json.Serialization;
using Undersoft.AEP.Core;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Setup : Entity, ISetup
    {
        public long? UnionId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Union Union { get; set; }

        public long? GroupId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Group Group { get; set; }

        public long? MemberId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Member Member { get; set; }

        public virtual EntityOnSets<Option> Settings { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long ISetup.VertexId => UnionId ?? default;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long ISetup.UsageSetId => GroupId ?? default;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long ISetup.SourceId => MemberId ?? default;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IFindable<IUsageOption> ISetup.UsageOptions => Settings.Cast<IUsageOption>().ToCatalog();
    }
}