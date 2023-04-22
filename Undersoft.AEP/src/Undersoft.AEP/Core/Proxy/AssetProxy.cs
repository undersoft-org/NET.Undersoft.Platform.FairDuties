using System.Instant.Linking;
using System.Series;
using RadicalR;

namespace Undersoft.AEP
{
    public class AssetProxy<TType, TRate, TObject> : AssetProxy
        where TObject : IAsset
        where TType : IAllocType
        where TRate : IAllocRate
    {
        private IDeck<ResourceModel<TType, TRate, TObject>> _resources;

        public AssetProxy(long assetId, IAllocSet allocSet) : base(assetId, allocSet) { }

        public new IEnumerable<TType> AllocTypes => base.AllocTypes.Cast<TType>();

        public new IDeck<TRate> AllocRates => Asset.AllocRates.Cast<TRate>().ToAlbum();

        public new IDeck<ResourceModel<TType, TRate, TObject>> Resources =>
            _resources ??= AllocRates
                .Select(
                    (ar, i) =>
                        new ResourceModel<TType, TRate, TObject>()
                        {
                            AllocType = (TType)AllocSet.Universe.AllocTypes[ar.AllocTypeId],
                            AllocRate = ar,
                            AssetId = Asset.Id,
                            Asset = this
                        }
                )
                .ToAlbum();

        public new TObject Asset
        {
            get => (TObject)base.Asset;
            set => base.Asset = value;
        }
    }

    public class AssetProxy : Identifiable, IAsset, IAssetProxy
    {
        private IDeck<IResource> _resources;

        public AssetProxy(long assetId, IAllocSet allocSet)
        {
            Id = assetId;
            AllocSet = allocSet;
            Asset = allocSet.Universe.Assets[assetId];
            Asset.AllocRates.ForEach(ar => ar.DependentOn.ForEach(ad => Asset.AllocRates[ad.TargetId].DependentByAny = true));
        }

        public IAllocSet AllocSet { get; }

        private IDeck<IAllocType> allocTypes;
        public virtual IDeck<IAllocType> AllocTypes =>
            allocTypes ??= AllocSet.Universe.AllocTypes
                .AsQueryable()
                .WhereIn(st => st.Id, Asset.AllocTypeLinks.Select(at => at.TargetId))
                .ToAlbum();

        public virtual IEnumerable<ILink> AllocTypeLinks => Asset.AllocTypeLinks;

        public virtual IFindable<IAllocRate> AllocRates => Asset.AllocRates;

        public virtual IDeck<IResource> Resources =>
            _resources ??= AllocRates
                .Select(
                    (ar, i) =>
                        new ResourceModel()
                        {
                            AllocTypeId = ar.AllocTypeId,
                            AllocType = AllocTypes[ar.AllocTypeId],
                            AllocRateId = ar.Id,
                            AllocRate = ar,
                            AssetId = Asset.Id,
                            Asset = this,
                            Ordinal = LastResourceOrdinal++
                        }
                )
                .ToAlbum<IResource>();

        public virtual IAsset Asset { get; set; }

        public long ConfigurationId => Asset.ConfigurationId;
        public IConfiguration Configuration => Asset.Configuration;

        public int LastRateOrdinal { get; set; }

        public int LastResourceOrdinal { get; set; }

        public int LastClaimOrdinal { get; set; }
    }
}
