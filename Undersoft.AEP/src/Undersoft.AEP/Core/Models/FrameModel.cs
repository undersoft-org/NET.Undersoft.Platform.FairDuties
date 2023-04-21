using System.Series;

namespace Undersoft.AEP
{
    public class FrameModel<TSlot, TAlloc> : Catalog<TSlot> where TSlot : ISlot where TAlloc : IAlloc
    {
        public FrameModel() { }

        public SequenceModel<TSlot, TAlloc> Sequence { get; set; }

        public float Checksum { get; set; }

        public float Capacity { get; set; }

        public IDeck<IAlloc> Allocs { get; set; }

        public IDeck<IClaim> Claims { get; set; }

        public IDeck<IResource> Resources { get; set; }
    }
}
