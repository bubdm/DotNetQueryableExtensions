using System;
using System.Collections.Generic;
using DBissari.QueryableExtensions.Options;

namespace DBissari.QueryableExtensions.Models
{
    public class PaginatedList<T>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }
        
        public IEnumerable<T> Items { get; set; }
        
        public PaginatedList()
        {}

        public PaginatedList(IEnumerable<T> pageItems, PaginationOptions paginationOptions, int totalItemsCount)
        {
            throw new NotImplementedException();
        }

        public bool HasNextPage => PageIndex < TotalPages;

        public bool HasPreviousPage => PageIndex > 1;
    }
}