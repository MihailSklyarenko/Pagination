using Microsoft.EntityFrameworkCore;

namespace Pagination.Types
{
    public class PagedResponse<T>
    {
        public List<T> Data { get; private set; }
        public Paging<T> Paging { get; private set; }

        public PagedResponse(List<T> source, int pageNumber, int pageSize)
        {
            int totalCount = source.Count;

            Data = source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            Paging = new Paging<T>(Data, totalCount, pageNumber, pageSize);
        }

        private PagedResponse(List<T> source, int pageNumber, int totalCount, int pageSize)
        {
            Data = source;
            Paging = new Paging<T>(Data, totalCount, pageNumber, pageSize);
        }

        public static async Task<PagedResponse<T>> GetPagedResponseAsync(IQueryable<T> source, int pageNumber, int pageSize, CancellationToken token)
        {
            var totalCount = await source.CountAsync(token);

            var items = await source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(token);


            return new PagedResponse<T>(items, pageNumber, totalCount, pageSize);
        }
    }
}