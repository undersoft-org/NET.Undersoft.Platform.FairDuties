using Microsoft.OData.Client;
using Undersoft.AEP;
using System.Runtime.Serialization;
using System.Series;
using System.Text.Json.Serialization;
using UltimatR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class User : Entity, IAsset
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public virtual DboToSet<UserRole> Roles { get; set; }

        public long? PersonalId { get; set; }
        public virtual Personal Personal { get; set; }

        public long? ConfigurationId { get; set; }
        public virtual Configuration Configuration { get; set; }

        public virtual Identifiers<User> Identifiers { get; set; }

        public virtual DboToSets<Attribute> Attributes { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboToSets<Organization> Organizations { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboToSets<Team> Teams { get; set; }

        public virtual DboToSets<ShiftType> ShiftTypes { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboToSets<Plan> Plans { get; set; }

        private DboToSet<ShiftRate> shiftRates;
        public virtual DboToSet<ShiftRate> ShiftRates
        {
            get
            {
                if (LastRateOrdinal == 0 && ShiftTypes.Count > 0)
                {
                    if (shiftRates == null)
                        shiftRates = new DboToSet<ShiftRate>();

                    if (shiftRates.Count != ShiftTypes.Count)
                    {


                        var rateIds = shiftRates.Select(x => x.Id);

                        ShiftTypes
                            .AsQueryable()
                            .ExceptIn(st => st.Id, rateIds)
                            .ForEach(
                                st =>
                                    ShiftRates.Add(new ShiftRate() { Ordinal = LastRateOrdinal++, ShiftTypeId = st.Id, ShiftType = st }
                            ));
                    }
                }
                return shiftRates;
            }
            set => shiftRates = value;
        }

        public int LastRateOrdinal { get; set; }

        public virtual DboSet<Shift> Shifts { get; set; }

        public virtual DboSet<ShiftRequest> ShiftRequests { get; set; }

        public virtual DboSet<Team> Leaderships { get; set; }

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
