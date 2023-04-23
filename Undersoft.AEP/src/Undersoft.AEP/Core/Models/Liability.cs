namespace Undersoft.AEP.Core
{
    public class Liability<TType, TEstimate> : Liability
        where TType : IAsset
        where TEstimate : IEstimate
    {
        public Liability() { }

        public new TEstimate Estimate
        {
            get => (TEstimate)base.Estimate;
            set => base.Estimate = value;
        }

        public new TType Asset
        {
            get => (TType)base.Asset;
            set => base.Asset = value;
        }
    }

    public class Liability : Raw.Liability, ILiability
    {
        public Liability() { }

        public virtual IAsset Asset { get; set; }

        public virtual IEstimate Estimate { get; set; }

        public virtual IUsageSet UsageSet { get; set; }
    }
}
