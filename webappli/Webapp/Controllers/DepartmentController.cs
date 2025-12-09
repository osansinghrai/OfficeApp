using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return Content("Random message");
        }
    }
}