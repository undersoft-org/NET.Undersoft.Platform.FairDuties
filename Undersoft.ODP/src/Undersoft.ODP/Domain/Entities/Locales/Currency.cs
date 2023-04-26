using RadicalR;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Undersoft.ODP.Domain
{
    public partial class Currency : Entity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public virtual EntitySet<Country> Countries { get; set; }

        public double Rate { get; set; }
    }
}
