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

        public IActionResult Edit(int Id) 
        {

            var employeeExists = _context.Employees.Any(x => x.Id == Id);
            if (!employeeExists)
            {
                return NotFound();
            }

            var employee = _context.Employees.Find(Id);

            UpdateEmployeeViewModel updateEmployeeViewModel = new UpdateEmployeeViewModel
            {
                Id = employee!.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Contact = employee.Contact,
                Address = employee.Address,
                PhotoPath = employee.PhotoPath,
                DepartmentId = employee.DepartmentId,
            };

            return View(updateEmployeeViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int Id, UpdateEmployeeViewModel employeeViewModel)
        {
            if (Id != employeeViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(employeeViewModel);
            }

            try
            {
                var employee = new Employee
                {
                    Id = employeeViewModel.Id,
                    FirstName = employeeViewModel.FirstName,
                    LastName = employeeViewModel.LastName,
                    Contact = employeeViewModel.Contact,
                    Address = employeeViewModel.Address,
                    DepartmentId = employeeViewModel.DepartmentId,
                };

                if (employeeViewModel.Photo != null && employeeViewModel.Photo.Length > 0)
                {
                    var FileName = Guid.NewGuid().ToString() + Path.GetExtension(employeeViewModel.Photo.FileName);

                    var uploadsFolder = $@"{_webHostEnvironment.WebRootPath}\ProfilePhotos";

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string AbsoluteFilePath = @$"{uploadsFolder}\{FileName}";

                    var FilePath = AbsoluteFilePath.Split("wwwroot")[1];

                    employee.PhotoPath = FilePath;

                    System.IO.File.Delete($@"{_webHostEnvironment.WebRootPath}\{employeeViewModel.PhotoPath}");

                    using (var fileStream = new FileStream(AbsoluteFilePath, FileMode.Create))
                    {
                        employeeViewModel.Photo.CopyTo(fileStream);
                    }
                }
                else
                {
                    employee.PhotoPath = employeeViewModel.PhotoPath;
                }

                _context.Employees.Update(employee);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Employees.Any(x => x.Id == Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
    }
}