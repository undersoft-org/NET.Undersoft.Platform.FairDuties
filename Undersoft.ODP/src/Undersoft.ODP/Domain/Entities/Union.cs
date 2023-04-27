using RadicalR;
using System.Runtime.Serialization;
using System.Series;
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

        public virtual EntitySet<Member> Members { get; set; }

        public virtual EntityOnSet<Vertex> Vertices { get; set; }

        public virtual EntityOnSet<Group> Groups { get; set; }

        public virtual EntityOnSet<Duty> Duties { get; set; }

        public long? SetupId { get; set; }
        public virtual Setup Setup { get; set; }

        private IFindable<ISource> sources;
        public IFindable<ISource> Sources => sources ??= Members.ToAlbum<ISource>();

        private IFindable<IUsageSet> usageSets;
        public IFindable<IUsageSet> UsageSets => usageSets ??= Groups.ToAlbum<IUsageSet>();

        ISetup IVertex.Setup => Setup;

        int IVertex.LastResourceOrdinal { get; set; }

        int IVertex.LastLiabilityOrdinal { get; set; }

        IFindable<IAsset> IVertex.Assets => Members.Cast<IAsset>().ToAlbum();
    }
}