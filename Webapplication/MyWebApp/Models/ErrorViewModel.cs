using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models;

public class Department
{

    [Key]
    public int Id { get; set; }

    [Display(Name = "Department Name")]
    [MinLength(5, ErrorMessage = "Department name must be at least 5 characters long.")]
    [Required(ErrorMessage = "Department name is required.")]
    [MaxLength(12, ErrorMessage = "Department name cannot exceed 12 characters.")]
    public string Name { get; set; }

     
}
