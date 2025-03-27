using BookStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportController : BaseController
    {
        private readonly ReportService reportService;
        public ReportController(ReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpGet("book")]
        public async Task<IActionResult> GetBooks(
           [FromQuery] string? searchKey,
           [FromQuery] int? authorId,
           [FromQuery] DateTime? fromPublishedDate,
           [FromQuery] DateTime? toPublishedDate,
           [FromQuery] int pageSize = 10,
           [FromQuery] int pageIndex = 1
        )
        {
            try
            {
                var books = await reportService.SearchBooks(searchKey, authorId, fromPublishedDate, toPublishedDate, pageSize, pageIndex);

                return Ok(new
                {
                    message = "Books retrieved successfully",
                    data = books
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return ServerErrorResponse();
            }
        }
    }
}
