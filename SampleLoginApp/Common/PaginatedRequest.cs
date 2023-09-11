using Microsoft.AspNetCore.Mvc;

namespace SampleLoginApp.Common
{
    public class PaginatedRequest
    {

        public const int ITEMS_PER_PAGE = 10;

        [FromQuery(Name = "p")]
        public int PageNumber { get; set; } = 1;

    }
}
