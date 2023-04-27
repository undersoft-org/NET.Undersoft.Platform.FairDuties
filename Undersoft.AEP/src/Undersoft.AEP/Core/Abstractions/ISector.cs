using System.Series;

namespace Undersoft.AEP.Core
{
    public interface ISector<TSlot, TUsage> : IUnique
        where TSlot : ISocket
        where TUsage : IUsage
    {
        float Capacity { get; set; }
        IDeck<ILiability> Liabilities { get; set; }
        IDeck<IResource> Resources { get; set; }
        IDeck<IUsage> Usages { get; set; }
        IVector<TSlot, TUsage> Vector { get; set; }
    }
}