using FiestApp_Infrastructure.Documents.Base;

namespace FiestApp_Infrastructure.Repositories.Base;

public class PagedResult<T> where T : IDocumentBase
{
    public IEnumerable<T> Items { get; set; } = [];
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
}

