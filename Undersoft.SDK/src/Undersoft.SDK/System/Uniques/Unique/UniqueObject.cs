using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Extract;
using System.Instant;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Uniques
{
    [DataContract]
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public class UniqueObject : IUniqueObject
    {
        private Uscn uniquecode;

        public UniqueObject() : this(true) { }

        public UniqueObject(bool autoId)
        {
            if (!autoId)
                return;

            uniquecode.UniqueKey = Unique.New;
            uniquecode.UniqueType = this.GetType().UniqueKey();
        }

        [Required]
        [StringLength(32)]
        [ConcurrencyCheck]
        [DataMember(Order = 0)]
        [FigureAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public virtual Uscn UniqueCode
        {
            get => uniquecode;
            set => uniquecode = value;
        }

        [FigureKey]
        [DataMember(Order = 1)]
        public virtual long Id
        {
            get => (long)uniquecode.UniqueKey;
            set => uniquecode.UniqueKey = (ulong)value;
        }

        [DataMember(Order = 2)]
        public virtual int Ordinal
        {
            get => (int)uniquecode.ValueFromXYZ(10, 25 * 1000);
            set => uniquecode.ValueToXYZ(10, 25 * 1000, (ulong)value);
        }

        [NotMapped]
        public virtual int TypeKey
        {
            get => (int)UniqueType;
            set => UniqueType = (uint)value;
        }

        [DataMember(Order = 3)]
        public virtual long SourceId { get; set; } = -1;

        [DataMember(Order = 4)]
        [FigureAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public virtual string SourceType { get; set; }

        [DataMember(Order = 5)]
        public virtual long TargetId { get; set; } = -1;

        [DataMember(Order = 6)]
        [FigureAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public virtual string TargetType { get; set; }

        [DataMember(Order = 7)]
        [FigureAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public virtual string Label { get; set; }

        [NotMapped]
        public virtual int OriginKey
        {
            get { return (int)uniquecode.UniqueOrigin; }
            set { uniquecode.UniqueOrigin = (uint)value; }
        }

        [DataMember(Order = 8)]
        [FigureAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public virtual string OriginName { get; set; }

        [DataMember(Order = 9)]
        [FigureAs(UnmanagedType.I8, SizeConst = 8)]
        public virtual DateTime Modified { get; set; } = DateTime.Now;

        [DataMember(Order = 10)]
        [FigureAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public virtual string Modifier { get; set; }

        [DataMember(Order = 11)]
        [FigureAs(UnmanagedType.I8, SizeConst = 8)]
        public virtual DateTime Created { get; set; }

        [DataMember(Order = 12)]
        [FigureAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public virtual string Creator { get; set; }

        [DataMember(Order = 255)]
        [Column(Order = 255)]
        [FigureAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public virtual string CodeNumber { get; set; }

        [NotMapped]
        public virtual ulong UniqueKey
        {
            get => uniquecode.UniqueKey;
            set => uniquecode.UniqueKey = value;
        }

        [NotMapped]
        public virtual ulong UniqueType
        {
            get => uniquecode.UniqueType;
            set => uniquecode.UniqueType = value;
        }

        public int CompareTo(IUnique other)
        {
            return uniquecode.CompareTo(other);
        }

        public bool Equals(IUnique other)
        {
            return uniquecode.Equals(other);
        }

        public byte[] GetBytes()
        {
            return this.GetStructureBytes();
        }

        public byte[] GetUniqueBytes()
        {
            return uniquecode.GetUniqueBytes();
        }
    }
}
