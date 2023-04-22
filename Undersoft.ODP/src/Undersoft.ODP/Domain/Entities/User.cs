using Microsoft.OData.Client;
using System.Instant.Linking;
using System.Runtime.Serialization;
using System.Series;
using System.Text.Json.Serialization;
using RadicalR;
using Undersoft.AEP;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class User : Entity, IAsset
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public virtual EntityOnSet<UserRole> Roles { get; set; }

        public long? PersonalId { get; set; }
        public virtual Personal Personal { get; set; }

        public long? ConfigurationId { get; set; }
        public virtual Configuration Configuration { get; set; }

        public virtual Identifiers<User> Identifiers { get; set; }

        public virtual EntityOnSets<Attribute> Attributes { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Organization> Organizations { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Team> Teams { get; set; }

        public virtual EntityOnSets<ShiftType> ShiftTypes { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSets<Plan> Plans { get; set; }

        private EntityOnSet<ShiftRate> shiftRates;
        public virtual EntityOnSet<ShiftRate> ShiftRates
        {
            get
            {
                if (LastRateOrdinal == 0 && ShiftTypes.Count > 0)
                {
                    if (shiftRates == null)
                        shiftRates = new EntityOnSet<ShiftRate>();

                    if (shiftRates.Count != ShiftTypes.Count)
                    {


                        var rateIds = shiftRates.Select(x => x.Id);

                        ShiftTypes
                            .AsQueryable()
                            .ExceptIn(st => st.Id, rateIds)
                            .ForEach(
                                st =>
                                    shiftRates.Add(new ShiftRate() { Ordinal = LastRateOrdinal++, ShiftTypeId = st.Id, ShiftType = st }
                            ));
                    }
                }
                return shiftRates;
            }
            set => shiftRates = value;
        }

        public int LastRateOrdinal { get; set; }

        public virtual EntitySet<Shift> Shifts { get; set; }

        public virtual EntitySet<ShiftRequest> ShiftRequests { get; set; }

        public virtual EntitySet<Team> Leaderships { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        public IFindable<IAllocRate> AllocRates => allocRates ??= ShiftRates.ToAlbum<IAllocRate>();
        private IFindable<IAllocRate> allocRates;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IEnumerable<ILink> IAsset.AllocTypeLinks => ShiftTypes.Select(i => new Link<User, ShiftType>() { SourceId = Id, TargetId = i.Id });

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IAsset.ConfigurationId => ConfigurationId ?? default;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IConfiguration IAsset.Configuration => Configuration;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        public override string Label => UserName;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int IAsset.LastResourceOrdinal { get; set; }
    }
}
