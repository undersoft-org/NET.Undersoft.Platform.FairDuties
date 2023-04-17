using System.Series;

namespace Undersoft.AEP
{
    public interface IAllocSetProxy : IAllocSet
    {
        IAllocSet AllocSet { get; set; }
        IFindable<IAllocType> AllocTypes { get; }
        IFindable<IAssetProxy> Assets { get; }
        IDeck<IClaim> Claims { get; }
        IDeck<IResource> Resources { get; }
    }
}