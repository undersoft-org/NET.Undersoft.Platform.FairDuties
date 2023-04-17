using System.Uniques;

namespace Undersoft.AEP
{
    public interface IAlloc : IUniqueEntry
    {
        long CurrentId { get; }
    }

    public interface IAllocModel : IAlloc
    {
        IAllocable Current { get; }

        IAllocable Source { get; set; }

        IAllocModel Target { get; set; }
    }
}