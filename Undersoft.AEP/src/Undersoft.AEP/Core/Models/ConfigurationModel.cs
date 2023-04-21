using System.Series;

namespace Undersoft.AEP
{
    public class ConfigurationModel : Configuration, IConfiguration
    {
        public virtual IFindable<IAllocOption> AllocOptions { get; set; }
    }
}