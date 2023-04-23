using RadicalR;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Undersoft.ODP.Domain
{
    [DataContract]
    public partial class Client : Entity
    {
        public string Name { get; set; }

        public string SerialNumber { get; set; }

        public string HostName { get; set; }

        public string Model { get; set; }

        public string MachineName { get; set; }

        public string OsVersion { get; set; }

        public string ClientDoamin { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntitySet<Profile> Profiles { get; set; }

        public virtual EntityOnSet<Session> Sessions { get; set; }

        public virtual Identifiers<Client> Identifiers { get; set; }
    }
}
