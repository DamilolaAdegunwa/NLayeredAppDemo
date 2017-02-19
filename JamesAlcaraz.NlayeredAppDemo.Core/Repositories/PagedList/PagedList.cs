using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesAlcaraz.NlayeredAppDemo.Core.Repositories.PagedList
{
    /// <summary>
    /// Represents a subset of a collection of objects
    /// </summary>
    /// <typeparam name="T">Type of object the collection should contain</typeparam>
    public class PagedList<T> : IPagedList<T>
    {
        /// <summary>
        /// This will be the container of the paged list / subset
        /// Not property because it will be exposed publicly via the IEnumerable implmentation
        /// </summary>
        protected readonly List<T> Subset = new List<T>();

        protected PagedList()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="superSet">The one-based index of the subset of objects contained by this instance.</param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize">Max size of any individual subset</param>
        public PagedList(IEnumerable<T> superSet, int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException("pageNumber", "PageNumber cannot be below 1.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize", "PageSize cannot be less than 1.");


            TotalItemCount = superSet == null ? 0 : superSet.Count();
            PageSize = pageSize;
            PageCount = TotalItemCount > 0
                        ? (int)Math.Ceiling(TotalItemCount / (double)PageSize)
                        : 0;
            PageNumber = (pageNumber == int.MaxValue) ? PageCount : pageNumber;
            HasPreviousPage = PageNumber > 1;
            HasNextPage = PageNumber < PageCount;

            if (superSet != null && TotalItemCount > 0)
            {
                Subset.AddRange(pageNumber == 1
                    ? superSet.Take(pageSize).ToList()
                    : superSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList());
            }
                
        }

        public int TotalItemCount { get; protected set; }
        public int PageNumber { get; protected set; }
        public int PageSize { get; protected set; }
        public int PageCount { get; protected set; }

        public bool HasPreviousPage { get; protected set; }
        public bool HasNextPage { get; protected set; }

        /// <summary>
        /// Implicit implementation of IEnumerable, makes this accessible to the class and 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return Subset.GetEnumerator();
        }

        /// <summary>
        /// Explicit implementation of IEnumerable allows it to only be accessible when cast as the interface itself
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        ///<summary>
        ///	Gets the element at the specified index.
        ///</summary>
        ///<param name = "index">The zero-based index of the element to get.</param>
        public T this[int index]
        {
            get { return Subset[index]; }
        }

        /// <summary>
        /// Returns subset, mainly for serialization
        /// </summary>
        public IEnumerable<T> Items
        {
            get { return Subset; }
        }
    }
}
