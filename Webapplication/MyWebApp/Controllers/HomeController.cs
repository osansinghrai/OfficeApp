using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Controllers
{

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Index(int A)
        {
            return View();
        }


        public IActionResult About()
        {
            return View();
        }
    }
}