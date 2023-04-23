using Undersoft.ODP.Domain;
using RadicalR;

namespace Undersoft.ODP.Api
{
    public class Setup : Dto
    {
        public long? UnionId { get; set; }

        public long? GroupId { get; set; }

        public long? UserId { get; set; }

        public virtual DtoSet<Option> Settings { get; set; }
    }
}