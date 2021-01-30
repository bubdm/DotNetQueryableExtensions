using System;
using System.Linq;
using DBissari.QueryableExtensions.Models;

namespace DBissari.QueryableExtensions
{
    public static class QueryablePaginationExtensions
    {
        /// <summary>
        /// Creates a paginated list from the current <see cref="IQueryable{T}"/> collection using the given parameters.
        /// </summary>
        /// <param name="source">The current <see cref="IQueryable{T}"/> collection.</param>
        /// <param name="pageIndex">The expected paginated list page index.</param>
        /// <param name="pageSize">The expected paginated list page size.</param>
        /// <typeparam name="T">The type of the objects contained in the collection.</typeparam>
        /// <returns>The paginated list object.</returns>
        /// <exception cref="ArgumentException">Thrown if the page index is lower than 1.</exception>
        /// <exception cref="ArgumentException">Thrown if the page size is lower than 1.</exception>
        /// <exception cref="ArgumentException">Thrown if the page index is greater than the computed total pages.</exception>
        public static PaginatedList<T> Paginate<T>(this IQueryable<T> source, int pageIndex = 1, int pageSize = 10)
        {
            if (pageIndex < 1)
                throw new ArgumentException("Page index can not be lower than 1", nameof(pageIndex));

            if (pageSize < 1)
                throw new ArgumentException("Page size can not be lower than 1", nameof(pageSize));
            
            var totalCount = source.Count();
            
            if (totalCount == 0)
                return new PaginatedList<T>
                {
                    PageItems = Array.Empty<T>()
                };
            
            var totalPages = (int) Math.Ceiling(totalCount / (double) pageSize);

            if (pageIndex > totalPages)
                throw new ArgumentException("Page index can not be greater than computed total pages", 
                    nameof(pageIndex));
            
            var items = source
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            
            return new PaginatedList<T>
            {
                PageItems = items,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalItemsCount = totalCount
            };
        }
    }
}
