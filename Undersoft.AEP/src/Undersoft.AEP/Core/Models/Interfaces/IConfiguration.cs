using System.Series;
using RadicalR;

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