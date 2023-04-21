namespace Undersoft.AEP
{
    public class ClaimModel<TType, TRate> : ClaimModel
        where TType : IAllocType
        where TRate : IAllocRate
    {
        public ClaimModel() { }

        public new TRate AllocRate
        {
            get => (TRate)base.AllocRate;
            set => base.AllocRate = value;
        }

        public new TType AllocType
        {
            get => (TType)base.AllocType;
            set => base.AllocType = value;
        }
    }

    public class ClaimModel : Claim, IClaim
    {
        public ClaimModel() { }

        public virtual IAllocType AllocType { get; set; }

        public virtual IAllocRate AllocRate { get; set; }

        public virtual IAllocSet AllocSet { get; set; }
    }
}
