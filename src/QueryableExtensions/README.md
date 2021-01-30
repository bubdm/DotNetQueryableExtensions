## Features

### Pagination

```csharp
using DBissari.QueryableExtensions;
using DBissari.QueryableExtensions.Models;
using System.Linq;
...
IQueryable<T> queryable = ...; // Create your IQueryable object however you want

int pageIndex = 1;
int pageSize = 10;

PaginatedList<T> paginatedList = queryable.Paginate(pageIndex, pageSize); // do whatever you want with your paginated list object
...
```
