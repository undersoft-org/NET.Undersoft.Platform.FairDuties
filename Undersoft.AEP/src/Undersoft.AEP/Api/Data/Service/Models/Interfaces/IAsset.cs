using System.Series;
using UltimatR;

namespace Undersoft.AEP
{
    public interface IAsset : IIdentifiable
    {
        public int LastRateOrdinal { get; set; }

        public int LastResourceOrdinal { get; set; }

        IFindable<IAllocRate> AllocRates { get; }

        IEnumerable<ILink> AllocTypeLinks { get; }

        long ConfigurationId { get; }
        IConfiguration Configuration { get; }
    }
}