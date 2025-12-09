using Microsoft.AspNetCore.Mvc;
using OfficeApp.Models;
using OfficeApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace OfficeApp.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmployeeController(AppDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(_context.Employees.Include(x => x.Department).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {

            if (employeeViewModel.Photo == null && !(employeeViewModel?.Photo?.Length > 0))
            {
                ModelState.AddModelError(nameof(employeeViewModel.Photo), "Please, add a photo.");

                return View(employeeViewModel);
            }
            else if (!ModelState.IsValid)
            {
                return View(employeeViewModel);
            }
            else 
            {
                var FileName = Guid.NewGuid().ToString() + Path.GetExtension(employeeViewModel.Photo.FileName);

                Employee employee = new Employee
                {
                    FirstName = employeeViewModel.FirstName,
                    LastName = employeeViewModel.LastName,
                    Contact = employeeViewModel.Contact,
                    Address = employeeViewModel.Address,
                    DepartmentId = employeeViewModel.DepartmentId
                };

                var uploadsFolder = $@"{_webHostEnvironment.WebRootPath}\ProfilePhotos";

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string AbsoluteFilePath = @$"{uploadsFolder}\{FileName}";

                var FilePath = AbsoluteFilePath.Split("wwwroot")[1];

                employee.PhotoPath = FilePath;

                using (var fileStream = new FileStream(AbsoluteFilePath, FileMode.Create))
                {
                    employeeViewModel.Photo.CopyTo(fileStream);
                }

                _context.Employees.Add(employee);
                _context.SaveChanges();


                return RedirectToAction(nameof(Index));
            }
        }
    }
}
