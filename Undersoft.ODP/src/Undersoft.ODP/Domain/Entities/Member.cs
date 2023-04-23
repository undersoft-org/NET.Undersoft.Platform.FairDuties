using RadicalR;
using System.Instant.Linking;
using System.Series;
using Undersoft.AEP.Core;
using Undersoft.AEP.Raw;

namespace Undersoft.ODP.Domain
{
    public class Member : Entity, ISource
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public virtual EntitySet<Role> Roles { get; set; }

        public long? ProfilelId { get; set; }
        public virtual Profile Profile { get; set; }

        public long? SetupId { get; set; }
        public virtual Setup Setup { get; set; }

        public virtual Identifiers<Member> Identifiers { get; set; }

        public virtual EntityOnSets<Property> Properties { get; set; }

        public virtual EntityOnSets<Union> Unions { get; set; }

        public virtual EntityOnSets<Group> Groups { get; set; }

        public virtual EntityOnSets<Asset> Assets { get; set; }

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
        private EntityOnSet<Estimate> estimates;

        public virtual EntityOnSets<Vertex> Vertices { get; set; }

        public int LastEstimateOrdinal { get; set; }

        public virtual EntityOnSet<Duty> Duties { get; set; }

        public virtual EntityOnSet<Request> Requests { get; set; }

        public virtual EntityOnSet<Group> Leaderships { get; set; }

        IFindable<IEstimate> ISource.Estimates => _estimates ??= Estimates.ToCatalog<IEstimate>();
        private IFindable<IEstimate> _estimates;

        IEnumerable<ILink> ISource.AssetLinks => Assets.Select(i => new Link<Member, Asset>() { SourceId = Id, TargetId = i.Id });

        long ISource.SetupId => SetupId ?? default;

        ISetup ISource.Setup => Setup;

        int ISource.LastResourceOrdinal { get; set; }
    }
}
