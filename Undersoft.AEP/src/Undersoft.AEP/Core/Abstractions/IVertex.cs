using System.Series;

namespace Undersoft.AEP.Core
{
    public interface IVertex : IUnique, IId
    {
        string Name { get; set; }

        public int LastEstimateOrdinal { get; set; }

        public int LastResourceOrdinal { get; set; }

        public int LastLiabilityOrdinal { get; set; }

        IFindable<IUsageSet> UsageSets { get; }

        IFindable<IAsset> Assets { get; }

        IFindable<ISource> Sources { get; }

        long? SetupId { get; }
        ISetup Setup { get; }
    }
}