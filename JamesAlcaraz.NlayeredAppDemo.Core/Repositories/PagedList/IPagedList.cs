using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesAlcaraz.NlayeredAppDemo.Core.Repositories.PagedList
{
    public interface IPagedList<out T> : IEnumerable<T>
    {
        /// <summary>
        /// Total number of objects contained within the superset.
        /// </summary>
        /// <value>
        /// Total number of objects contained within the superset.
        /// </value>
        int TotalItemCount { get; }

        /// <summary>
        /// Total number of subsets within the superset.
        /// </summary>
        int PageCount { get; }

        /// <summary>
        /// One-based index of this subset within the superset.
        /// </summary>
        int PageNumber { get; }

        /// <summary>
        /// Maximum size any individual subset.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Returns true if this is NOT the first subset within the superset.
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// Returns true if this is NOT the last subset within the superset.
        /// </summary>
        bool HasNextPage { get; }

        T this[int index] { get; }

    }
}
