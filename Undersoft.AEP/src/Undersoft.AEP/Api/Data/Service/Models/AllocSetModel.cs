using System.Series;
using UltimatR;

namespace Undersoft.AEP
{
    public class AllocSetModel : AllocSet, IAllocSet
    {
        public IUniverse Universe { get; set; }

        public IEnumerable<ILink> AssetLinks { get; set; }

        public IEnumerable<ILink> AllocTypeLinks { get; set; }

        public IEnumerable<ILink> AllocRateLinks { get; set; }

        public IFindable<IAllocRate> AllocRates { get; set; }

        public IConfiguration Configuration { get; set; }
    }
}
