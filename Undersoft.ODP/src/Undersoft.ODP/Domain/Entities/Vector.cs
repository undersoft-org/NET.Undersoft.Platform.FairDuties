using Microsoft.OData.Client;
using RadicalR;
using System.Runtime.Serialization;
using System.Series;
using System.Text.Json.Serialization;
using Undersoft.AEP;
using Undersoft.AEP.Core;

namespace Undersoft.ODP.Domain
{
    [DataContract]
    public class Vector : Entity, IVector
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool IsView { get; set; }

        public long? GroupId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        public virtual Group Group { get; set; }

        public long? GroupViewId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        public virtual Group GroupView { get; set; }

        public virtual EntitySet<Duty> Duties { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        public virtual EntitySet<Duty> DutyViews { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IFindable<IUsage> IVector.Usages
        {
            get =>
                Duties
                    .Select(s => new Usage<Duty>() { Source = s.Member, SourceId = s.Id })
                    .ToAlbum<IUsage>();
            set =>
                value.ForOnly(
                    v => !Duties.Contains(v.CurrentId),
                    v => Duties.Add((Duty)v.Current)
                );
        }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        IUsageSet IVector.UsageSet
        {
            get => new UsageSetProxy(GroupId ?? default, Group.Union);
            set => Group = (Group)(value);
        }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        long IVector.UsageSetId
        {
            get => GroupId ?? default;
            set => GroupId = value;
        }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int IVector.BlockOffset
        {
            get => new DateTimeOffset(StartTime).Offset.Days;
            set => throw new NotImplementedException();
        }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int IVector.BlockCount
        {
            get => new DateTimeOffset(EndTime).Offset.Days - ((IVector)this).BlockOffset;
            set => throw new NotImplementedException();
        }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int IVector.SectorOffset
        {
            get => (int)Calendarium.CreateItem(StartTime).DayOfWeek;
            set => throw new NotImplementedException();
        }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int IVector.LastSectorId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int IVector.LastBlockId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int IVector.LastSocketId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int IVector.LastUsageId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int IVector.LastAssetOrdinal { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int IVector.LastEstimateOrdinal { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int IVector.LastResourceOrdinal { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [IgnoreClientProperty]
        int IVector.LastLiabilityOrdinal { get; set; }
    }
}
