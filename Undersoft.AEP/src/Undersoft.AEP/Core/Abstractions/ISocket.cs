using RadicalR;
using System.Uniques;

namespace Undersoft.AEP.Core
{
    public interface ISocket : IUniqueObject
    {
        float Checksum { get; set; }

        long VectorId { get; set; }

        long SectorId { get; set; }

        long BlockId { get; set; }

        long LiabilityId { get; set; }
        ILiability Liability { get; set; }

        long ResourceId { get; set; }
        IResource Resource { get; set; }

        long UsageId { get; set; }
        IUsage Usage { get; set; }
    }
}