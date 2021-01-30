using System;
using System.Linq;
using Xunit;

namespace DBissari.QueryableExtensions.Tests
{
    public class QueryablePaginationExtensionsTests
    {
        private static IQueryable<T> GetQueryable<T>(int size) => new T[size].AsQueryable();
        
        [Theory]
        [InlineData(10, 20, 1)]
        [InlineData(15, 25, 2)]
        [InlineData(15, 35, 3)]
        [InlineData(30, 20, 1)]
        public void Paginate_ReturnsPaginatedList(int pageSize, int totalSize, int pageIndex)
        {
            var queryable = GetQueryable<object>(totalSize);
            var totalPages = (int) Math.Ceiling(totalSize / (double) pageSize);

            var paginatedList = queryable.Paginate(pageIndex, pageSize);
            
            Assert.NotNull(paginatedList);
            Assert.Equal(pageIndex, paginatedList.PageIndex);
            Assert.Equal(pageSize, paginatedList.PageSize);
            Assert.InRange(paginatedList.PageItems.Count, 1, pageSize);
            Assert.Equal(totalSize, paginatedList.TotalItemsCount);
            Assert.Equal(totalPages, paginatedList.TotalPages);
        }
        
        [Fact]
        public void Paginate_ReturnsAnEmptyPaginatedList_IfQueryableIsEmpty()
        {
            var queryable = GetQueryable<object>(0);

            var paginatedList = queryable.Paginate();
            
            Assert.NotNull(paginatedList);
            Assert.Empty(paginatedList.PageItems);
        }
        
        [Theory]
        [InlineData(50, 0, 1)]
        [InlineData(50, 10, 0)]
        [InlineData(50, -5, 1)]
        [InlineData(50, 10, -10)]
        [InlineData(50, 10, 10)]
        public void Paginate_ThrowsArgumentException_IfParamsAreNotCorrect(int totalSize, int pageSize, int pageIndex)
        {
            var queryable = GetQueryable<object>(totalSize);

            Assert.Throws<ArgumentException>(() => queryable.Paginate(pageIndex, pageSize));
        }
    }
}