using System.Series;
using UltimatR;

namespace Undersoft.AEP
{
    public interface IUniverse : IUnique, IId
    {
        string Name { get; set; }

        public int LastRateOrdinal { get; set; }

        public int LastResourceOrdinal { get; set; }

        public int LastClaimOrdinal { get; set; }

        IFindable<IAllocSet> AllocSets { get; }

        IFindable<IAllocType> AllocTypes { get; }

        IFindable<IAsset> Assets { get; }

        long? ConfigurationId { get; }
        IConfiguration Configuration { get; }
    }
}