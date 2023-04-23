using System.Series;

namespace Undersoft.AEP.Core
{
    public class Setup : Raw.Setup, ISetup
    {
        public virtual IFindable<IUsageOption> UsageOptions { get; set; }
    }
}