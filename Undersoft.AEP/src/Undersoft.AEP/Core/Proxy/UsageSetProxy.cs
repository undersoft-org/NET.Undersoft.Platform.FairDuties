using RadicalR;
using System.Instant;
using System.Instant.Linking;
using System.Series;

namespace Undersoft.AEP.Core
{
    public class UsageSetProxy<TType, TEstimate, TObject> : UsageSetProxy
        where TObject : IUsageSet
        where TType : IAsset
        where TEstimate : IEstimate
    {
        private IDeck<Liability<TType, TEstimate>> _claims;

        public UsageSetProxy(long allocSetId, IVertex universe) : base(allocSetId, universe) { }

        public new IEnumerable<TType> Assets => base.Assets.Cast<TType>();

        public new IDeck<TEstimate> Estimates => base.Estimates.Cast<TEstimate>().ToAlbum();

        public new IDeck<Liability<TType, TEstimate>> Liabilities =>
            _claims ??= Estimates
                .Select(
                    (ar, i) =>
                        new Liability<TType, TEstimate>()
                        {
                            AssetId = (long)ar.AssetId,
                            Asset = (TType)UsageSet.Vertex.Assets[ar.AssetId],
                            EstimateId = ar.Id,
                            Estimate = ar,
                            UsageSetId = UsageSet.Id,
                            UsageSet = this
                        }
                )
                .ToAlbum();

        public new TObject UsageSet
        {
            get => (TObject)base.UsageSet;
            set => base.UsageSet = value;
        }
    }

    public class UsageSetProxy : Identifiable, IUsageSet, IUsageSetProxy
    {
        private IDeck<ILiability> _claims;
        private IDeck<IResource> _resources;

        public UsageSetProxy(long allocSetId, IVertex universe)
        {
            Vertex = universe;
            VertexId = universe.Id;
            UsageSet = universe.UsageSets[allocSetId];
            Id = allocSetId;
        }

        public IUsageSet UsageSet { get; set; }

        public virtual IFindable<IEstimate> Estimates => UsageSet.Estimates;

        private IDeck<IAsset> assets;
        public virtual IFindable<IAsset> Assets =>
            assets ??= UsageSet.Vertex.Assets
                .AsQueryable()
                .WhereIn(st => st.Id, AssetLinks.Select(al => al.TargetId)).ToAlbum();

        public virtual IEnumerable<ILink> AssetLinks => UsageSet.AssetLinks;

        public virtual IDeck<ILiability> Liabilities =>
            _claims ??= Estimates.OrderBy(o => o.Ordinal)
                .Select(
                    (ar, i) =>
                        new Liability()
                        {
                            AssetId = (long)ar.AssetId,
                            Asset = Assets[ar.AssetId],
                            EstimateId = ar.Id,
                            Estimate = ar,
                            UsageSetId = UsageSet.Id,
                            UsageSet = this,
                            Ordinal = LastLiabilityOrdinal++
                        }
                )
                .ToCatalog<ILiability>();

        private IDeck<ISourceProxy> sources;
        public virtual IFindable<ISourceProxy> Sources =>
            sources ??= SourceLinks.ForEach(al => new SourceProxy(al.TargetId, UsageSet)).ToCatalog<ISourceProxy>();
        public virtual IEnumerable<ILink> SourceLinks => UsageSet.SourceLinks;

        public virtual IDeck<IResource> Resources =>
            _resources ??= new Catalog<IResource>(Sources.OrderBy(a => a.Ordinal).SelectMany(a => a.Resources).Select(r => r.PatchTo(new Resource())));

        public long SetupId => UsageSet.SetupId;
        public ISetup Setup => UsageSet.Setup;

        public long VertexId { get; set; }
        public IVertex Vertex { get; set; }

        public int SectorSize
        {
            get => UsageSet.SectorSize;
            set => UsageSet.SectorSize = value;
        }

        public int BlockSize
        {
            get => UsageSet.BlockSize;
            set => UsageSet.BlockSize = value;
        }

        public float BlockSeed
        {
            get => UsageSet.BlockSeed;
            set => UsageSet.BlockSeed = value;
        }

        public float SectorCapacity
        {
            get => UsageSet.SectorCapacity;
            set => UsageSet.SectorCapacity = value;
        }

        public float BlockCapacity
        {
            get => UsageSet.BlockCapacity;
            set => UsageSet.BlockCapacity = value;
        }

        public int LastEstimateOrdinal { get; set; }

        public int LastResourceOrdinal { get; set; }

        public int LastLiabilityOrdinal { get; set; }
    }
}
