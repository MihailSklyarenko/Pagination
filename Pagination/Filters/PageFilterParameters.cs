namespace Pagination.Filters;

public abstract class PageFilterParameters
{
    public int PageNumber { get; set; } = 1;

    private readonly int _maxPageSize = 50;
    private int _pageSize = 10;

    public PageFilterParameters()
    {
    }

    public PageFilterParameters(int maxPageSize)
    {
        _maxPageSize = maxPageSize;
    }

    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = (value > _maxPageSize) ? _maxPageSize : value;
        }
    }
}
