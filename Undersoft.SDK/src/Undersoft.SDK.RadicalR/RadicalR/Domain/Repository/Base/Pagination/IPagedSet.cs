using System.Collections.Generic;
using System.Linq;

namespace RadicalR
{
    #region Interfaces

    public interface IPagedSet<T> 
    {
        #region Properties

        bool HasNextPage { get; }

        bool HasPreviousPage { get; }

        int IndexFrom { get; }

        IList<T> Items { get; }

        int PageIndex { get; }

        int PageSize { get; }

        int TotalCount { get; }

        int TotalPages { get; }

        #endregion
    }

    #endregion
}
