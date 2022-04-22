namespace Pagination.Filters;

public abstract class PageFilterParameters
{
    private readonly int _maxPageSize = 50;

    private int _pageNumber = 1;
    private int _pageSize = 10;

    public int PageNumber
    {
        get
        {
            return _pageNumber;
        }
        set
        {
            _pageNumber = value <= 0 ? _pageNumber : value;
        }
    }

    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = (value <= 0) ? _maxPageSize : value;
        }
    }
}
