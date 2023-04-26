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

        public virtual Group Group { get; set; }

        public long? GroupViewId { get; set; }

        public virtual Group GroupView { get; set; }

        public virtual EntitySet<Duty> Duties { get; set; }

        public virtual EntitySet<Duty> DutyViews { get; set; }

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

        IUsageSet IVector.UsageSet
        {
            get => new UsageSetProxy(GroupId ?? default, Group.Union);
            set => Group = (Group)(value);
        }

        long IVector.UsageSetId
        {
            get => GroupId ?? default;
            set => GroupId = value;
        }

        int IVector.BlockOffset
        {
            get => new DateTimeOffset(StartTime).Offset.Days;
            set => throw new NotImplementedException();
        }

        int IVector.BlockCount
        {
            get => new DateTimeOffset(EndTime).Offset.Days - ((IVector)this).BlockOffset;
            set => throw new NotImplementedException();
        }

        int IVector.SectorOffset
        {
            get => (int)Calendarium.CreateItem(StartTime).DayOfWeek;
            set => throw new NotImplementedException();
        }

        int IVector.LastSectorId { get; set; }

        int IVector.LastBlockId { get; set; }

        int IVector.LastSocketId { get; set; }

        int IVector.LastUsageId { get; set; }

        int IVector.LastAssetOrdinal { get; set; }

        int IVector.LastEstimateOrdinal { get; set; }

        int IVector.LastResourceOrdinal { get; set; }

        int IVector.LastLiabilityOrdinal { get; set; }
    }
}
