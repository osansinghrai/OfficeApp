using Microsoft.EntityFrameworkCore;
using OfficeApp.Models;
using OfficeApp.Services.Abstraction;

namespace OfficeApp.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {

        private readonly AppDBContext _context;

        public DepartmentService(AppDBContext context) // Dependency Injection
        {
            _context = context;
        }

        public Department CreateDepartment(Department department)
        {
            var result = _context.Departments.Add(department);
            _context.SaveChanges();

            return result.Entity;

        }

        public void DeleteDepartment(int Id)
        {
            var result = _context.Departments.Find(Id);
            if (result != null)
            {
                _context.Departments.Remove(result);
                _context.SaveChanges();
            }
        }

        public List<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public Department GetDepartmentById(int Id)
        {
            return _context.Departments.Find(Id);
        }

        public async Task<Department> GetDepartmentByIdAsync(int Id)
        {
            return await _context.Departments.FindAsync(Id);
        }

        public Department UpdateDepartment(Department department)
        {
            try
            {
                var result= _context.Departments.Update(department);
                _context.SaveChanges();

                return result.Entity;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Departments.Any(e => e.Id == department.Id))
                {
                    return null;
                }
                else
                {
                    var result = _context.Departments.Update(department);
                    _context.SaveChanges();

                    return result.Entity;
                }
            }
        }
    }
}