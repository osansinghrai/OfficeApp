using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models;

public class Employee

{
  
    [Key]
    public int Id { get; set; }

    [Display(Name = "First Name")]
    [MinLength(5, ErrorMessage = "Employee name must be at least 5 characters long.")]
    [Required(ErrorMessage = "Employee Firstname is required.")]
    [MaxLength(12, ErrorMessage = "Employee name cannot exceed 12 characters.")]
    public string FirstName { get; set; }

    [Display(Name = "Last Name")]
    [MinLength(5, ErrorMessage = "Employee name must be at least 5 characters long.")]
    [Required(ErrorMessage = "Employee Lastname is required.")]
    [MaxLength(12, ErrorMessage = "Employee name cannot exceed 12 characters.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Contact number should start with 9.")]

    public int ContactNumber { get; set; }


    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; } 



     
}