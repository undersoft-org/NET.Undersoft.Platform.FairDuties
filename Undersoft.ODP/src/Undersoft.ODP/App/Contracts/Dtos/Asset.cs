using RadicalR;
using System.Runtime.Serialization;
using Undersoft.ODP.Domain;

namespace Undersoft.ODP.Api
{
    [DataContract]
    public class Asset : Dto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DutyUnit Unit { get; set; }

        public double Value { get; set; }

        public virtual DtoSet<Asset> DependentOn { get; set; }

        public virtual DtoSet<Asset> RelatedTo { get; set; }

        public virtual DtoSet<Asset> OptionalTo { get; set; }
    }
}
