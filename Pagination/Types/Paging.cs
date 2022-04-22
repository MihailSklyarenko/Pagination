namespace Pagination.Types;

public sealed class Paging<T>
{
    public int CurrentPage { get; private set; }
    public int TotalPagesCount { get; private set; }
    public int PageSize { get; private set; }
    public int TotalItemsCount { get; private set; }
    public bool HasPreviousPage => CurrentPage > 1;
    public bool HasNextPage => CurrentPage < TotalPagesCount;

    public Paging(List<T> items, int totalCount, int pageNumber, int pageSize)
    {
        TotalItemsCount = totalCount;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPagesCount = (int)Math.Ceiling(totalCount / (double)pageSize);
    }
}
