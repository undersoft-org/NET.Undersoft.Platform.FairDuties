using RadicalR;
using System.Series;
using System.Uniques;

namespace Undersoft.AEP.Core
{
    public interface ISetup : IUniqueObject
    {
        long VertexId { get; }

        long UsageSetId { get; }

        long SourceId { get; }

        IFindable<IUsageOption> UsageOptions { get; }
    }
}