using Microsoft.OData.Client;
using RadicalR;
using System.Runtime.Serialization;
using System.Series;
using System.Text.Json.Serialization;
using Undersoft.AEP.Core;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Union : Entity, IVertex
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public string Notices { get; set; }

        public virtual EntitySet<Property> Properties { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntitySet<Asset> Assets { get; set; }

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
                                    estimates.Add(new Estimate() { Ordinal = LastEstimateOrdinal++, AssetId = st.Id, Asset = st })
                            );
                    }
                }
                return estimates;
            }
            set => estimates = value;
        }

        public int LastEstimateOrdinal { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntitySet<Member> Members { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSet<Vertex> Vertices { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSet<Group> Groups { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSet<Duty> Duties { get; set; }

        public long? SetupId { get; set; }
        public virtual Setup Setup { get; set; }

        private IFindable<ISource> sources;
        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        public IFindable<ISource> Sources => sources ??= Members.ToAlbum<ISource>();

        private IFindable<IUsageSet> usageSets;
        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        public IFindable<IUsageSet> UsageSets => usageSets ??= Groups.ToAlbum<IUsageSet>();

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        ISetup IVertex.Setup => Setup;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int IVertex.LastResourceOrdinal { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int IVertex.LastLiabilityOrdinal { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IFindable<IAsset> IVertex.Assets => Members.Cast<IAsset>().ToAlbum();
    }
}