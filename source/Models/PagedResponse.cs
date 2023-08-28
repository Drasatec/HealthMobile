namespace alrahmacare00.Models;

public class PagedResponse<T>
{
    public int Total { get; set; }
    public int? Page { get; set; }
    public int? PageSize { get; set; }
    public List<T> Data { get; set; }
}
