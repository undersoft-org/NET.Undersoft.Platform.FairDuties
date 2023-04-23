using RadicalR;
using System.Series;

namespace Undersoft.AEP.Core
{
    public interface ISetup : IIdentifiable
    {
        long VertexId { get; }

        long UsageSetId { get; }

        long SourceId { get; }

        IFindable<IUsageOption> UsageOptions { get; }
    }
}