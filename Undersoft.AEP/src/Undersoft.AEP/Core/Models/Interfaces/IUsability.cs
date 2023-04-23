using RadicalR;

namespace Undersoft.AEP.Core
{
    public interface IUsability : IIdentifiable
    {
        long VertexId { get; }

        long UsageSetId { get; }

        long AssetId { get; set; }

        long EstimateId { get; set; }

        long VectorId { get; set; }

        long SectorId { get; set; }

        long BlockId { get; set; }

        long SocketId { get; set; }

        long ResourceId { get; set; }

        long UsageId { get; set; }
    }
}