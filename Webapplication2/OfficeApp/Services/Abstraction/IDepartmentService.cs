
using OfficeApp.Models;
using System.Collections.Generic;

namespace OfficeApp.Services.Abstraction
{
  public interface IDepartmentService
  {
    List<Department> GetAllDepartments();
    int GetAllDepartmentsCount();
    Department? GetDepartmentsById(int id);

    Department CreateDepartment(Department department);
    Department? UpdateDepartment(Department department);

    void DeleteDepartment(int id);

    Department? GetDepartmentById(int id);
  }
}