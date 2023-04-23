using Microsoft.OData.Client;
using RadicalR;
using System.Instant.Linking;
using System.Runtime.Serialization;
using System.Series;
using System.Text.Json.Serialization;
using Undersoft.AEP.Core;
using Undersoft.AEP.Raw;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Member : Entity, ISource
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public virtual EntityOnSet<Role> Roles { get; set; }

        public long? PersonalId { get; set; }
        public virtual Profile Personal { get; set; }

        public long? SetupId { get; set; }
        public virtual Setup Setup { get; set; }

        public virtual Identifiers<Member> Identifiers { get; set; }

        public virtual EntityOnSets<Property> Properties { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Union> Unions { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Group> Groups { get; set; }

        public virtual EntityOnSets<Asset> Assets { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Vertex> Plans { get; set; }

        private EntityOnSet<Estimate> estimates;
        public virtual EntityOnSet<Estimate> Estimates
        {
            get
            {
                if (LastEstimateOrdinal == 0 && Assets.Count > 0)
                {
                    if (estimates == null)
                        estimates = new EntityOnSet<Estimate>();

                    if (estimates.Count != Assets.Count)
                    {


                        var rateIds = estimates.Select(x => x.Id);

                        Assets
                            .AsQueryable()
                            .ExceptIn(st => st.Id, rateIds)
                            .ForEach(
                                st =>
                                    estimates.Add(new Estimate() { Ordinal = LastEstimateOrdinal++, AssetId = st.Id, Asset = st }
                            ));
                    }
                }
                return estimates;
            }
            set => estimates = value;
        }

        public int LastEstimateOrdinal { get; set; }

        public virtual EntitySet<Duty> Frames { get; set; }

        public virtual EntitySet<Request> Requests { get; set; }

        public virtual EntitySet<Group> Leaderships { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IFindable<IEstimate> ISource.Estimates => _estimates ??= Estimates.ToAlbum<IEstimate>();
        private IFindable<IEstimate> _estimates;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IEnumerable<ILink> ISource.AssetLinks => Assets.Select(i => new Link<Member, Asset>() { SourceId = Id, TargetId = i.Id });

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long ISource.SetupId => SetupId ?? default;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        ISetup ISource.Setup => Setup;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        public override string Label => UserName;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int ISource.LastResourceOrdinal { get; set; }
    }
}
