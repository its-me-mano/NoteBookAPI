﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Helper
{
    public class PageList<T>:List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => (CurrentPage > 1);
        public bool HasNext => (CurrentPage < TotalPages);
        public PageList(List<T> items, int totalCount,int currentPage,int pageSize) {
            CurrentPage = currentPage;
            TotalCount = totalCount;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            AddRange(items);
        }

        public static PageList<T> Create(IQueryable<T> source, int pageNumber, int pageSize) {
            int count = source.Count();
            List<T> items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }
}
