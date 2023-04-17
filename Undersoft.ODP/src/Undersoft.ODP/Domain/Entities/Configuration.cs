using Microsoft.OData.Client;
using Undersoft.AEP;
using System.Runtime.Serialization;
using System.Series;
using System.Text.Json.Serialization;
using UltimatR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Configuration : Entity, IConfiguration
    {
        public long? OrganizationId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Organization Organization { get; set; }

        public long? TeamId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Team Team { get; set; }

        public long? UserId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual User User { get; set; }

        public virtual DboToSets<Setting> Settings { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IConfiguration.UniverseId => OrganizationId ?? default;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IConfiguration.AllocSetId => TeamId ?? default;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IConfiguration.AssetId => UserId ?? default;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IFindable<IAllocOption> IConfiguration.AllocOptions => Settings.Cast<IAllocOption>().ToDeck();
    }
}