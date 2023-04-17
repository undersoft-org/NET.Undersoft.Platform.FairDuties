using System.Uniques;

namespace System
{
    public interface ISerialCode : IUnique
    {
        Uscn SerialCode { get; }
    }
}
