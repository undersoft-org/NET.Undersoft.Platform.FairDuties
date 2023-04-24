using RadicalR;
using System.Instant.Linking;
using System.Series;

namespace Undersoft.AEP.Core
{
    public class SourceProxy<TType, TEstimate, TObject> : SourceProxy
        where TObject : ISource
        where TType : IAsset
        where TEstimate : IEstimate
    {
        private IDeck<Resource<TType, TEstimate, TObject>> _resources;

        public SourceProxy(long assetId, IUsageSet allocSet) : base(assetId, allocSet) { }

        public new IEnumerable<TType> Assets => base.Assets.Cast<TType>();

        public new IDeck<TEstimate> Estimates => Source.Estimates.Cast<TEstimate>().ToAlbum();

        public new IDeck<Resource<TType, TEstimate, TObject>> Resources =>
            _resources ??= Estimates
                .Select(
                    (ar, i) =>
                        new Resource<TType, TEstimate, TObject>()
                        {
                            Asset = (TType)UsageSet.Vertex.Assets[ar.AssetId],
                            Estimate = ar,
                            SourceId = Source.Id,
                            Source = this
                        }
                )
                .ToAlbum();

        public new TObject Source
        {
            get => (TObject)base.Source;
            set => base.Source = value;
        }
    }

    public class SourceProxy : Identifiable, ISource, ISourceProxy
    {
        private IDeck<IResource> _resources;

        public SourceProxy(long assetId, IUsageSet allocSet)
        {
            Id = assetId;
            UsageSet = allocSet;
            Source = allocSet.Vertex.Sources[assetId];
            Source.Estimates.ForEach(ar => ar.DependentOn.ForEach(ad => Source.Estimates[ad.TargetId].DependentByAny = true));
        }

        public IUsageSet UsageSet { get; }

        private IDeck<IAsset> allocTypes;
        public virtual IDeck<IAsset> Assets =>
            allocTypes ??= UsageSet.Vertex.Assets
                .AsQueryable()
                .WhereIn(st => st.Id, Source.AssetLinks.Select(at => at.TargetId))
                .ToAlbum();

        public virtual IEnumerable<ILink> AssetLinks => Source.AssetLinks;

        public virtual IFindable<IEstimate> Estimates => Source.Estimates;

        public virtual IDeck<IResource> Resources =>
            _resources ??= Estimates
                .Select(
                    (ar, i) =>
                        new Resource()
                        {
                            AssetId = (long)ar.AssetId,
                            Asset = Assets[ar.AssetId],
                            EstimateId = ar.Id,
                            Estimate = ar,
                            SourceId = Source.Id,
                            Source = this,
                            Ordinal = LastResourceOrdinal++
                        }
                )
                .ToAlbum<IResource>();

        public virtual ISource Source { get; set; }

        public long SetupId => Source.SetupId;
        public ISetup Setup => Source.Setup;

        public int LastEstimateOrdinal { get; set; }

        public int LastResourceOrdinal { get; set; }

        public int LastLiabilityOrdinal { get; set; }
    }
}
