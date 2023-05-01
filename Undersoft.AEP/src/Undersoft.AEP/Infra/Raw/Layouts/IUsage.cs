using System.Uniques;

namespace Undersoft.AEP.Raw
{
    public interface IUsage : IUniqueObject
    {
        long CurrentId { get; }
    }
}
