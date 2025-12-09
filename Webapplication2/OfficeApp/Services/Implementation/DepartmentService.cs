using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OfficeApp;
using OfficeApp.Models;
using OfficeApp.Services.Abstraction;

namespace OfficeApp.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDBContext _context;

        public DepartmentService(AppDBContext context)
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
            var department = _context.Departments.Find(Id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }

        public List<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public int GetAllDepartmentsCount()
        {
            return _context.Departments.Count();
        }

        public Department? GetDepartmentsById(int id)
        {
            return _context.Departments.Find(id);
        }

        // helper/alias
        public Department? GetDepartmentById(int Id)
        {
            return GetDepartmentsById(Id);
        }

        public Department? UpdateDepartment(Department department)
        {
            try
            {
                var result = _context.Departments.Update(department);
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
                     throw;
                }
            }
        }

    
  }
}