using AutoMapper;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using UltimatR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Contact : Entity
    {
        public virtual string Name { get; set; }

        public virtual ContactType Type { get; set; }

        public virtual string Email { get; set; }

        public virtual PhoneType PhoneType { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual string Notices { get; set; }

        public virtual DboToSet<Address> Addresses { get; set; }

        [IgnoreMap]
        [JsonIgnore]
        public virtual DboSet<Personal> Personals { get; set; }
    }

}
