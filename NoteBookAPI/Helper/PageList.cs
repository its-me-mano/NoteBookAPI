using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Helper
{
    public class PageList<T>:List<T>
    {
        ///<summary>
        ///CurrentPage
        ///</summary>
        public int CurrentPage { get; set; }
        ///<summary>
        ///TotalPages
        ///</summary>
        public int TotalPages { get; set; }
        ///<summary>
        ///PageSize
        ///</summary>
        public int PageSize { get; set; }
        ///<summary>
        ///Total count of users
        ///</summary>
        public int TotalCount { get; set; }
        ///<summary>
        ///PageListing
        ///</summary>
        public PageList(List<T> items, int totalCount,int currentPage,int pageSize) {
            CurrentPage = currentPage;
            TotalCount = totalCount;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            AddRange(items);
        }
        ///<summary>
        ///Setpaging
        ///</summary>
        public static PageList<T> Create(IQueryable<T> source, int pageNumber, int pageSize) {
            int count = source.Count();
            List<T> items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }
}
