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

        public int OnDuties { get; set; }

        public int OffDuties { get; set; }

        public int FreeDuties { get; set; }

        public int Exchanges { get; set; }

        public bool DependentByAny { get; set; }

        public bool OptionalFromAny { get; set; }

        public long? GroupId { get; set; }

        public long? MemberId { get; set; }

        [FigureKey]
        public long? AssetId { get; set; }

        public virtual DtoSet<Estimate> DependentOn { get; set; }

        public virtual DtoSet<Estimate> OptionalTo { get; set; }

    }
}
