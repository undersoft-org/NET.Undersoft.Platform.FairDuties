namespace Undersoft.AEP
{
    public class ResourceModel<TType, TRate, TObject> : ResourceModel
        where TObject : IAsset
        where TType : IAllocType
        where TRate : IAllocRate
    {
        public ResourceModel() { }

        public new AssetProxy<TType, TRate, TObject> Asset
        {
            get => (AssetProxy<TType, TRate, TObject>)base.Asset;
            set => base.Asset = value;
        }
    }

    public class ResourceModel : Resource, IResource
    {
        public ResourceModel() { }

        public virtual IAllocType AllocType { get; set; }

        public virtual IAllocRate AllocRate { get; set; }

        public virtual IAllocSet AllocSet { get; set; }

        public virtual IAsset Asset { get; set; }
    }
}
