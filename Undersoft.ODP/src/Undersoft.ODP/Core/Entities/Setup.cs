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
        public virtual Union Union { get; set; }

        public long? GroupId { get; set; }
        public virtual Group Group { get; set; }

        public long? MemberId { get; set; }
        public virtual Member Member { get; set; }

        public virtual EntityOnSets<Option> Options { get; set; }

        long ISetup.VertexId => UnionId ?? default;

        long ISetup.UsageSetId => GroupId ?? default;

        long ISetup.SourceId => MemberId ?? default;

        IFindable<IUsageOption> ISetup.UsageOptions => Options.Cast<IUsageOption>().ToCatalog();
    }
}