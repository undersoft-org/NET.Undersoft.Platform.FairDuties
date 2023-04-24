namespace Undersoft.AEP.Core
{
    public class Resource<TType, TEstimate, TObject> : Resource
        where TObject : ISource
        where TType : IAsset
        where TEstimate : IEstimate
    {
        public Resource() { }

        public new SourceProxy<TType, TEstimate, TObject> Source
        {
            get => (SourceProxy<TType, TEstimate, TObject>)base.Source;
            set => base.Source = value;
        }
    }

    public class Resource : Raw.Resource, IResource
    {
        public Resource() { }

        public virtual IAsset Asset { get; set; }

        public virtual IEstimate Estimate { get; set; }

        public virtual IUsageSet UsageSet { get; set; }

        public virtual ISource Source { get; set; }
    }
}
