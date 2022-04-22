using Microsoft.EntityFrameworkCore;

namespace Pagination.Types;

public class PagedList<T>
{
    public List<T> Data { get; private set; } = new List<T>();

    public int CurrentPage { get; private set; }
    public int TotalPagesCount { get; private set; }
    public int PageSize { get; private set; }
    public int TotalItemsCount { get; private set; }
    public bool HasPreviousPage => CurrentPage > 1;
    public bool HasNextPage => CurrentPage < TotalPagesCount;

    private PagedList(List<T> items, int totalCount, int pageNumber, int pageSize)
    {
        TotalItemsCount = totalCount;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPagesCount = (int)Math.Ceiling(totalCount / (double)pageSize);

        Data.AddRange(items);
    }

    public static async Task<PagedList<T>> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize, CancellationToken token)
    {
        var items = await source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(token);

        var totalCount = items.Count;

        return new PagedList<T>(items, totalCount, pageNumber, pageSize);
    }

    public static PagedList<T> ToPagedList(List<T> source, int pageNumber, int pageSize)
    {
        int totalCount = source.Count;

        var items = source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var result = new PagedList<T>(items, totalCount, pageNumber, pageSize);

        return result;
    }
}
