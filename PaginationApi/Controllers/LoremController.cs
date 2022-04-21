using Microsoft.AspNetCore.Mvc;
using Pagination;
using PaginationApi.Models;
using System.Text.Json;

namespace PaginationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoremController : ControllerBase
    {
        private static readonly List<Lorem> _loremTop20 = new()
        {
            new Lorem { Title = "lorem"},
            new Lorem { Title = "ipsum" },
            new Lorem { Title = "dolor" },
            new Lorem { Title = "sit" },
            new Lorem { Title = "amet" },
            new Lorem { Title = "consectetuer" },
            new Lorem { Title = "adipiscing" },
            new Lorem { Title = "elit" },
            new Lorem { Title = "sed" },
            new Lorem { Title = "diam" },
            new Lorem { Title = "nonummy" },
            new Lorem { Title = "nibh" },
            new Lorem { Title = "euismod" },
            new Lorem { Title = "tincidunt" },
            new Lorem { Title = "ut" },
            new Lorem { Title = "laoreet" },
            new Lorem { Title = "dolore" },
            new Lorem { Title = "magna" },
            new Lorem { Title = "aliquam" },
            new Lorem { Title = "doleratore" }
        };

        private readonly ILogger<LoremController> _logger;

        public LoremController(ILogger<LoremController> logger)
        {
            _logger = logger;
        }

        [HttpPost("filter")]
        public PagedList<Lorem> GetForecast(GetLoremRequest loremRequest)
        {
            _logger.LogInformation(JsonSerializer.Serialize(loremRequest));
            return PagedList<Lorem>.ToPagedList(_loremTop20, loremRequest.PageNumber, loremRequest.PageSize);
        }
    }
}