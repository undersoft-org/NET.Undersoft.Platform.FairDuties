using System.Series;

namespace Undersoft.AEP.Core
{
    public interface IUsageSetProxy : IUsageSet
    {
        IUsageSet UsageSet { get; set; }
        IFindable<IAsset> Assets { get; }
        IFindable<ISourceProxy> Sources { get; }
        IDeck<ILiability> Liabilities { get; }
        IDeck<IResource> Resources { get; }
    }
}