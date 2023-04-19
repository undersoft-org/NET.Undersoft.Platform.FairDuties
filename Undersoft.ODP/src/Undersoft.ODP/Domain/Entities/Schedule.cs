using Microsoft.OData.Client;
using Undersoft.AEP;
using System.Runtime.Serialization;
using System.Series;
using System.Text.Json.Serialization;
using UltimatR;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Schedule : Entity, ISequence
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool IsView { get; set; }

        public long? TeamId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        public virtual Team Team { get; set; }

        public long? TeamViewId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        public virtual Team TeamView { get; set; }

        public virtual EntityOnSet<Shift> Shifts { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        public virtual EntityOnSets<Shift> ShiftViews { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IFindable<IAllocModel> ISequence.Allocs
        {
            get =>
                Shifts
                    .Select(s => new AllocModel<Shift>() { Source = s, SourceId = s.Id })
                    .ToAlbum<IAllocModel>();
            set =>
                value.ForOnly(
                    v => !Shifts.Contains(v.CurrentId),
                    v => Shifts.Add((Shift)v.Current)
                );
        }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IAllocSet ISequence.AllocSet
        {
            get => new AllocSetProxy(TeamId ?? default, Team.Organization);
            set => Team = (Team)(value);
        }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long ISequence.AllocSetId
        {
            get => TeamId ?? default;
            set => TeamId = value;
        }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int ISequence.FrameOffset
        {
            get => new DateTimeOffset(StartTime).Offset.Days;
            set => throw new NotImplementedException();
        }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int ISequence.FrameCount
        {
            get => new DateTimeOffset(EndTime).Offset.Days - ((ISequence)this).FrameOffset;
            set => throw new NotImplementedException();
        }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int ISequence.BlockOffset
        {
            get => (int)CalendarHelper.CreateItem(StartTime).DayOfWeek;
            set => throw new NotImplementedException();
        }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int ISequence.LastBlockId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int ISequence.LastFrameId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int ISequence.LastSlotId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int ISequence.LastAllocId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int ISequence.LastAllocOrdinal { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int ISequence.LastRateOrdinal { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int ISequence.LastResourceOrdinal { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int ISequence.LastClaimOrdinal { get; set; }
    }
}
