using Microsoft.OData.Client;
using Undersoft.AEP;
using System.Runtime.Serialization;
using System.Series;
using System.Text.Json.Serialization;
using UltimatR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Team : Entity, IAllocSet
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public ShiftUnit ShiftUnit { get; set; } = ShiftUnit.Day;

        public float FrameCapacity { get; set; } = 3;

        public float BlockCapacity { get; set; } = 21;

        public int FrameSize { get; set; } = 1;

        public int BlockSize { get; set; } = 7;

        public float FrameSeed { get; set; } = 0.416f;

        public long? OrganizationId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Organization Organization { get; set; }

        public long? LeadershipId { get; set; }
        public virtual User Leadership { get; set; }

        public long? ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }

        public virtual DboToSets<User> Users { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboToSet<ShiftRequest> ShiftRequests { get; set; }

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
                                    ShiftRates.Add(new ShiftRate() { Ordinal = LastRateOrdinal++, ShiftTypeId = st.Id, ShiftType = st })
                            );
                    }
                }
                return shiftRates;
            }
            set => shiftRates = value;
        }

        public int LastRateOrdinal { get; set; }

        public virtual DboSet<ShiftType> ShiftTypes { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboSet<Plan> Plans { get; set; }

        public virtual DboSet<Schedule> ScheduleViews { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DboSet<Shift> Shifts { get; set; }

        public virtual DboSet<Attribute> Attributes { get; set; }

        public long? ConfigurationId { get; set; }
        public virtual Configuration Configuration { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IAllocSet.UniverseId { get => OrganizationId ?? default; set => OrganizationId = value; }
        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IUniverse IAllocSet.Universe { get => Organization; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IEnumerable<ILink> IAllocSet.AssetLinks => Users.Select(i => new Link<Team, User>() { SourceId = Id, TargetId = i.Id });

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IEnumerable<ILink> IAllocSet.AllocTypeLinks => ShiftTypes.Select(i => new Link<Team, ShiftType>() { SourceId = Id, TargetId = i.Id });

        private IDeck<IAllocRate> allocRates;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        public IFindable<IAllocRate> AllocRates => allocRates ??= ShiftRates.ToAlbum<IAllocRate>();

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IConfiguration IAllocSet.Configuration => Configuration;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IAllocSet.ConfigurationId { get => ConfigurationId ?? default; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int IAllocSet.LastResourceOrdinal { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int IAllocSet.LastClaimOrdinal { get; set; }
    }
}
