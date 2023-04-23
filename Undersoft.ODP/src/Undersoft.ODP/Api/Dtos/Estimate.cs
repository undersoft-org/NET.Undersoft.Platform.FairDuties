using System.Instant;
using RadicalR;

namespace Undersoft.ODP.Api
{
    public class Estimate : Dto
    {
        public string Name { get; set; }

        public double Checksum { get; set; }

        public double Rank { get; set; }

        public double Quantity { get; set; }

        public double Rate { get; set; }

        public double Value { get; set; }

        public double Total { get; set; }

        public int Weekly { get; set; }

        public int Monthly { get; set; }

        public int Yearly { get; set; }

        public int Weekends { get; set; }

        public int Holidays { get; set; }

        public int OnFrames { get; set; }

        public int OffFrames { get; set; }

        public int FreeFrames { get; set; }

        public int Exchanges { get; set; }

        public bool DependentByAny { get; set; }

        public long? GroupId { get; set; }

        public long? UserId { get; set; }

        [FigureKey]
        public long? FrameTypeId { get; set; }

        public virtual DtoSet<Estimate> DependentOn { get; set; }

        public virtual DtoSet<Estimate> OptionalTo { get; set; }

    }
}
