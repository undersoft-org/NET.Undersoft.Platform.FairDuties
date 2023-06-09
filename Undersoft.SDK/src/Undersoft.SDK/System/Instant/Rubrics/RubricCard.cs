﻿namespace System.Instant
{
    using System.Runtime.InteropServices;
    using System.Series;
    using System.Uniques;

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public class RubricCard : CardBase<MemberRubric>
    {
        private ulong _key;

        public RubricCard() { }

        public RubricCard(ICard<MemberRubric> value) : base(value) { }

        public RubricCard(MemberRubric value) : base(value) { }

        public RubricCard(object key, MemberRubric value) : base(key, value) { }

        public RubricCard(ulong key, MemberRubric value) : base(key, value) { }

        public override ulong Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public override int CompareTo(ICard<MemberRubric> other)
        {
            return (int)(Key - other.Key);
        }

        public override int CompareTo(object other)
        {
            return (int)(Key - other.UniqueKey64());
        }

        public override int CompareTo(ulong key)
        {
            return (int)(Key - key);
        }

        public override bool Equals(object y)
        {
            return Key.Equals(y.UniqueKey64());
        }

        public override bool Equals(ulong key)
        {
            return Key == key;
        }

        public override byte[] GetBytes()
        {
            return GetUniqueBytes();
        }

        public override int GetHashCode()
        {
            return (int)Key;
        }

        public unsafe override byte[] GetUniqueBytes()
        {
            byte[] b = new byte[8];
            fixed (byte* s = b)
                *(ulong*)s = _key;
            return b;
        }

        public override void Set(ICard<MemberRubric> card)
        {
            this.value = card.Value;
            _key = card.Key;
        }

        public override void Set(MemberRubric value)
        {
            this.value = value;
            _key = value.UniqueKey;
        }

        public override void Set(object key, MemberRubric value)
        {
            this.value = value;
            _key = key.UniqueKey64();
        }
    }
}
