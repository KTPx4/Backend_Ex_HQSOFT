using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult ServerErrorResponse()
        {
            return StatusCode(500, new {message = "Server is Busy. Try again!"});
        }
    }
    
}
