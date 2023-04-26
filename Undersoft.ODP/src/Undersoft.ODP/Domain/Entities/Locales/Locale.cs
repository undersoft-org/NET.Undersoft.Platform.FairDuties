using AutoMapper;
using RadicalR;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Locale : Entity
    {
        public virtual string Name { get; set; }

        public virtual LocaleType Type { get; set; }

        public virtual string Email { get; set; }

        public virtual PhoneType PhoneType { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual string Notices { get; set; }

        public virtual EntitySet<Address> Addresses { get; set; }

        public virtual EntitySet<Profile> Profiles { get; set; }
    }
}
