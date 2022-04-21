using Microsoft.EntityFrameworkCore;

namespace Pagination;

public class PagedList<T> : List<T>
{
    public int CurrentPage { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; }
    public int ItemsCount { get; private set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
       

    private PagedList(List<T> items, int totalCount, int pageNumber, int pageSize)
    {
        ItemsCount = totalCount;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(items.Count / (double)pageSize);
        
        AddRange(items);
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

        return new PagedList<T>(items, totalCount, pageNumber, pageSize);
    }
}
