using System.Collections.Generic;

namespace DBissari.QueryableExtensions.Models
{
    /// <summary>
    /// A class holding a paginated collection.
    /// </summary>
    /// <typeparam name="T">The type of the objects contained in the collection</typeparam>
    public class PaginatedList<T>
    {
        /// <summary>
        /// The asked page index.
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// The asked page size.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The count of all the objects contained in the great list from which was created the current paginated list.
        /// </summary>
        public int TotalItemsCount { get; set; }
        
        /// <summary>
        /// The count of all the avalaible pages regarding the pagination.
        /// </summary>
        public int TotalPages { get; set; }
        
        /// <summary>
        /// The items of the current page.
        /// </summary>
        public IList<T> PageItems { get; set; }
    }
}