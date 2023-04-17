using System.Series;
using UltimatR;

namespace Undersoft.AEP
{
    public interface IConfiguration : IIdentifiable
    {
        long UniverseId { get; }

        long AllocSetId { get; }

        long AssetId { get; }

        IFindable<IAllocOption> AllocOptions { get; }
    }
}