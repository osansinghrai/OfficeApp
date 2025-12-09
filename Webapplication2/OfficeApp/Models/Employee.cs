using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeApp.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }


    [Required (ErrorMessage = "First name is required.")]
    [Display(Name = "Employee First Name")]
    [MinLength(3, ErrorMessage =  "First name must be at least 3 characters long.")]
    [MaxLength(9, ErrorMessage = "First name cannot exceed 9 characters.")]
    public string FirstName { get; set; }

    [Required (ErrorMessage = "Last name is required.")]
    [Display(Name = "Employee Last Name")]
    [MinLength(3, ErrorMessage =  "Last name must be at least 3 characters long.")]
    [MaxLength(9, ErrorMessage = "Last name cannot exceed 9 characters.")]
    public string LastName { get; set; }


    [Required (ErrorMessage = "Contact number is required.")]
    [MinLength(10, ErrorMessage = "Contact number must be at least 10 digits long.")]
    [MaxLength(10, ErrorMessage = "Contact number cannot exceed 10 digits.")]
    public string Contact{ get; set; }

    [Display(Name = "Employee Address")]
    public string? Address { get; set; }

    [Required]
     public string PhotoPath { get; set;  }

     [ForeignKey(nameof(Department))]

     public int DepartmentId { get; set; }

     public Department Department { get; set; }

}