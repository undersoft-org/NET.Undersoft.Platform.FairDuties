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
    public class Group : Entity, IUsageSet
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public UOM Unit { get; set; } = UOM.Day;

        public float BlockCapacity { get; set; } = 3;

        public float SectorCapacity { get; set; } = 21;

        public int BlockSize { get; set; } = 1;

        public int SectorSize { get; set; } = 7;

        public float BlockSeed { get; set; } = 0.416f;

        public long? UnionId { get; set; }
        public virtual Union Union { get; set; }

        public long? LeadershipId { get; set; }
        public virtual Member Leadership { get; set; }

        public long? VectorId { get; set; }
        public virtual Vector Vector { get; set; }

        public virtual EntityOnSets<Member> Members { get; set; }

        public virtual EntityOnSet<Request> Requests { get; set; }

        private EntitySet<Estimate> estimates;
        public virtual EntitySet<Estimate> Estimates
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

        public virtual EntitySet<Asset> Assets { get; set; }

        public virtual EntitySet<Vertex> Vertices { get; set; }

        public virtual EntitySet<Vector> VectorViews { get; set; }

        public virtual EntitySet<Duty> Duties { get; set; }

        public virtual EntitySet<Property> Properties { get; set; }

        public long? SetupId { get; set; }
        public virtual Setup Setup { get; set; }

        long IUsageSet.VertexId { get => UnionId ?? default; set => UnionId = value; }
        IVertex IUsageSet.Vertex { get => Union; }

        IEnumerable<ILink> IUsageSet.SourceLinks => Members.Select(i => new Link<Group, Member>() { SourceId = Id, TargetId = i.Id });

        IEnumerable<ILink> IUsageSet.AssetLinks => Assets.Select(i => new Link<Group, Asset>() { SourceId = Id, TargetId = i.Id });

        ISetup IUsageSet.Setup => Setup;

        long IUsageSet.SetupId { get => SetupId ?? default; }

        int IUsageSet.LastResourceOrdinal { get; set; }

        int IUsageSet.LastLiabilityOrdinal { get; set; }

        IFindable<IEstimate> IUsageSet.Estimates => Estimates.Cast<IEstimate>().ToCatalog();
    }
}
