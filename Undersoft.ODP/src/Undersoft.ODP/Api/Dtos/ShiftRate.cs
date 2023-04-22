using System.Instant;
using RadicalR;

namespace Undersoft.ODP.Api
{
    public class ShiftRate : Dto
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

        public int OnShifts { get; set; }

        public int OffShifts { get; set; }

        public int FreeShifts { get; set; }

        public int Exchanges { get; set; }

        public bool DependentByAny { get; set; }

        public long? TeamId { get; set; }

        public long? UserId { get; set; }

        [FigureKey]
        public long? ShiftTypeId { get; set; }

        public virtual DtoSet<ShiftRate> DependentOn { get; set; }

        public virtual DtoSet<ShiftRate> OptionalTo { get; set; }

    }
}
