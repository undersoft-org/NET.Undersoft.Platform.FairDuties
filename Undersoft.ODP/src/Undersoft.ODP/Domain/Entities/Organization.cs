using Microsoft.OData.Client;
using System.Runtime.Serialization;
using System.Series;
using System.Text.Json.Serialization;
using RadicalR;
using Undersoft.AEP;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Organization : Entity, IUniverse
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public string Notices { get; set; }

        public virtual EntitySet<Attribute> Attributes { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntitySet<ShiftType> ShiftTypes { get; set; }

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
                                    shiftRates.Add(new ShiftRate() { Ordinal = LastRateOrdinal++, ShiftTypeId = st.Id, ShiftType = st })
                            );
                    }
                }
                return shiftRates;
            }
            set => shiftRates = value;
        }

        public int LastRateOrdinal { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntitySet<User> Users { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSet<Plan> Plans { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSet<Team> Teams { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual EntityOnSet<Shift> Shifts { get; set; }

        public long? ConfigurationId { get; set; }
        public virtual Configuration Configuration { get; set; }

        private IFindable<IAsset> assets;
        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        public IFindable<IAsset> Assets => assets ??= Users.ToAlbum<IAsset>();

        private IFindable<IAllocSet> allocSets;
        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        public IFindable<IAllocSet> AllocSets => allocSets ??= Teams.ToAlbum<IAllocSet>();

        private IFindable<IAllocType> allocTypes;
        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        public IFindable<IAllocType> AllocTypes => allocTypes ??= ShiftTypes.ToAlbum<IAllocType>();

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IConfiguration IUniverse.Configuration => Configuration;

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int IUniverse.LastResourceOrdinal { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int IUniverse.LastClaimOrdinal { get; set; }
    }
}