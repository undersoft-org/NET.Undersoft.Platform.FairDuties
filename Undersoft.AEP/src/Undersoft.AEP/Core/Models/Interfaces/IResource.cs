using RadicalR;

namespace Undersoft.AEP
{
    public interface IResource : IIdentifiable
    {
        IAllocType AllocType { get; set; }

        IAllocRate AllocRate { get; set; }

        IAllocSet AllocSet { get; set; }

        long AssetId { get; }
        IAsset Asset { get; set; }
    }
}