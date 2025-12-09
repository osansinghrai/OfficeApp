using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace OfficeApp.ViewModels
{
    public class EmployeeViewModel
    {
        public IFormFile? Photo { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Contact { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        [Required]
        public int DepartmentId { get; set; }
    }
}
