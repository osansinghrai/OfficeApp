
using Microsoft.AspNetCore.Mvc;
using OfficeApp.Models;
using OfficeApp.Services.Abstraction;
namespace OfficeApp.Controllers

{
        public class DepartmentController : Controller
    {
        private readonly AppDBContext _context;

        private readonly IDepartmentService _departmentService;

        public DepartmentController(AppDBContext context, IDepartmentService departmentService)
        {
            _context = context;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
             return View(_departmentService.GetAllDepartments());
        }
    
          public IActionResult Create()
        {
            return View();
        }

         [HttpPost]
         public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            { 
                _departmentService.CreateDepartment(department);
                return RedirectToAction("Index");
            }
            else 
            {
                return View(department);
            }
            
        }

        public  IActionResult Details(int Id)
        {
            var department =  _departmentService.GetDepartmentsById(Id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        public IActionResult Edit(int Id)
        {
            var department = _departmentService.GetDepartmentsById(Id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(int Id, Department department)
        {
            if (Id != department.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _departmentService.UpdateDepartment(department);
                 return RedirectToAction("Index");
            }
            return View(department);
        }

        public IActionResult Delete(int Id)
        {
            var department = _departmentService.GetDepartmentById(Id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        
        public IActionResult DeleteConfirmed(int Id)
        {
            _departmentService.DeleteDepartment(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}

