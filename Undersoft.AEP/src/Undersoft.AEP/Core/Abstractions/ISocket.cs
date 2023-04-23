using RadicalR;

namespace Undersoft.AEP.Core
{
    public interface ISocket : IIdentifiable
    {
        float Checksum { get; set; }

        long VectorId { get; set; }

        long BockId { get; set; }

        long FrameId { get; set; }

        long LiabilityId { get; set; }
        ILiability Liability { get; set; }

        long ResourceId { get; set; }
        IResource Resource { get; set; }

        long ExploitId { get; set; }
        IUsage Exploit { get; set; }
    }
}