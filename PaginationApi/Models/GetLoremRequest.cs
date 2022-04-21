using Pagination;

namespace PaginationApi.Models
{
    public class GetLoremRequest : PageFilterParameters
    {
        public GetLoremRequest() : base(10){}
    }
}