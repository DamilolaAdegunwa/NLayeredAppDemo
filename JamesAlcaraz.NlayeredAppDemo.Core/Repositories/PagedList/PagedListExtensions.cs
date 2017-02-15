using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Core.Repositories;

namespace JamesAlcaraz.NlayeredAppDemo.Core.Repositories.PagedList
{
    public static class PagedListExtensions
    {
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> superSet, int pageNumber, int pageSize)
        {
            return new PagedList<T>(superSet, pageNumber, pageSize);
        }
    }
}
