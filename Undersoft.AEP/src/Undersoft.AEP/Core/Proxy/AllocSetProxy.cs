using System.Instant;
using System.Series;
using UltimatR;

namespace Undersoft.AEP
{
    public class AllocSetProxy<TType, TRate, TObject> : AllocSetProxy
        where TObject : IAllocSet
        where TType : IAllocType
        where TRate : IAllocRate
    {
        private IDeck<ClaimModel<TType, TRate>> _claims;

        public AllocSetProxy(long allocSetId, IUniverse universe) : base(allocSetId, universe) { }

        public new IEnumerable<TType> AllocTypes => base.AllocTypes.Cast<TType>();

        public new IDeck<TRate> AllocRates => base.AllocRates.Cast<TRate>().ToAlbum();

        public new IDeck<ClaimModel<TType, TRate>> Claims =>
            _claims ??= AllocRates
                .Select(
                    (ar, i) =>
                        new ClaimModel<TType, TRate>()
                        {
                            AllocTypeId = ar.AllocTypeId,
                            AllocType = (TType)AllocSet.Universe.AllocTypes[ar.AllocTypeId],
                            AllocRateId = ar.Id,
                            AllocRate = ar,
                            AllocSetId = AllocSet.Id,
                            AllocSet = this
                        }
                )
                .ToAlbum();

        public new TObject AllocSet
        {
            get => (TObject)base.AllocSet;
            set => base.AllocSet = value;
        }
    }

    public class AllocSetProxy : Identifiable, IAllocSet, IAllocSetProxy
    {
        private IDeck<IClaim> _claims;
        private IDeck<IResource> _resources;

        public AllocSetProxy(long allocSetId, IUniverse universe)
        {
            Universe = universe;
            UniverseId = universe.Id;
            AllocSet = universe.AllocSets[allocSetId];
            Id = allocSetId;
        }

        public IAllocSet AllocSet { get; set; }

        private IDeck<IAllocType> allocTypes;
        public virtual IFindable<IAllocType> AllocTypes =>
            allocTypes ??= AllocSet.Universe.AllocTypes
                .AsQueryable()
                .WhereIn(st => st.Id, AllocSet.AllocTypeLinks.Select(at => at.TargetId))
                .ToAlbum();

        public virtual IEnumerable<ILink> AllocTypeLinks => AllocSet.AllocTypeLinks;

        public virtual IFindable<IAllocRate> AllocRates => AllocSet.AllocRates;

        public virtual IDeck<IClaim> Claims =>
            _claims ??= AllocRates.OrderBy(o => o.Ordinal)
                .Select(
                    (ar, i) =>
                        new ClaimModel()
                        {
                            AllocTypeId = ar.AllocTypeId,
                            AllocType = AllocTypes[ar.AllocTypeId],
                            AllocRateId = ar.Id,
                            AllocRate = ar,
                            AllocSetId = AllocSet.Id,
                            AllocSet = this,
                            Ordinal = LastClaimOrdinal++
                        }
                )
                .ToCatalog<IClaim>();

        public virtual IEnumerable<ILink> AssetLinks => AllocSet.AssetLinks;

        private IDeck<IAssetProxy> assets;
        public virtual IFindable<IAssetProxy> Assets =>
            assets ??= AssetLinks.ForEach(al => new AssetProxy(al.TargetId, AllocSet)).ToCatalog<IAssetProxy>();

        public virtual IDeck<IResource> Resources =>
            _resources ??= new Catalog<IResource>(Assets.OrderBy(a => a.Ordinal).SelectMany(a => a.Resources).Select(r => r.PatchTo(new ResourceModel())));

        public long ConfigurationId => AllocSet.ConfigurationId;
        public IConfiguration Configuration => AllocSet.Configuration;

        public long UniverseId { get; set; }
        public IUniverse Universe { get; set; }

        public int FrameSize
        {
            get => AllocSet.FrameSize;
            set => AllocSet.FrameSize = value;
        }

        public int BlockSize
        {
            get => AllocSet.BlockSize;
            set => AllocSet.BlockSize = value;
        }

        public float FrameSeed
        {
            get => AllocSet.FrameSeed;
            set => AllocSet.FrameSeed = value;
        }

        public float FrameCapacity
        {
            get => AllocSet.FrameCapacity;
            set => AllocSet.FrameCapacity = value;
        }

        public float BlockCapacity
        {
            get => AllocSet.BlockCapacity;
            set => AllocSet.BlockCapacity = value;
        }

        public int LastRateOrdinal { get; set; }

        public int LastResourceOrdinal { get; set; }

        public int LastClaimOrdinal { get; set; }
    }
}
