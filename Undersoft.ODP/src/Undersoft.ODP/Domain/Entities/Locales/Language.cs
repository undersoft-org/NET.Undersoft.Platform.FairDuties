using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using RadicalR;

namespace Undersoft.ODP.Domain
{
    public class Language : Entity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public virtual EntityOnSet<Country> Countries { get; set; }
    }
}
