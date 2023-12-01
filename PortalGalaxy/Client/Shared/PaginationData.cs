namespace PortalGalaxy.Client.Shared;

public class PaginationData
{
    public int CurrentPage { get; set; }
    public int RowPerPage { get; set; }
    public int TotalPages { get; set; }
    public int RowCount { get; set; }
}

public class PagedResult<T> : PaginationData
{
    public ICollection<T> Results { get; set; } = new List<T>();
}