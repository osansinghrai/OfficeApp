
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;


namespace MyWebApp.Controllers
{
         public class DepartmentController : Controller
    {

      List<Department> Departments = new List<Department>
      {
        new Department { Id = 1, Name = "Human Resources" },
        new Department { Id = 2, Name = "Finance" }
      };
               public IActionResult Index()
    {
      var Department = new Department
      {
        Id = 1,
        Name = "Human Resources"
      };

      return View(Department);

    }

   public IActionResult List()
    {
      return View(Departments);
    }
}
}
