using System;
using System.Linq;
using System.Threading.Tasks;
using DBissari.QueryableExtensions.Models;
using DBissari.QueryableExtensions.Options;

namespace DBissari.QueryableExtensions
{
    public static class QueryablePaginationExtensions
    {
        public static async Task<PaginatedList<T>> PaginateAsync<T>(this IQueryable<T> source, PaginationOptions paginationOptions)
        {
            throw new NotImplementedException();
        }
    }
}
