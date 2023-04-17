﻿namespace System
{
    using System.Collections.Specialized;
    using System.Reflection;

    public interface ISerialNumber<V> : ISerialNumber
    {
        Type IdentifierType { get; }

        FieldInfo[] KeyFields { get; }

        V Value { get; }
    }

    public interface ISerialNumber
        : IUnique,
            IEquatable<BitVector32>,
            IEquatable<DateTime>,
            IEquatable<ISerialNumber>
    {
        ushort BlockZ { get; set; }

        ushort BlockY { get; set; }

        ushort BlockX { get; set; }

        byte Priority { get; set; }

        byte Flags { get; set; }

        long Time { get; set; }

        ulong ValueFromXYZ(uint vectorZ, uint vectorY);

        ulong ValueToXYZ(ulong vectorZ, ulong vectorY, ulong value);
    }
}
