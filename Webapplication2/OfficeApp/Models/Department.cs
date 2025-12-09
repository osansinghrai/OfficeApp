using System.ComponentModel.DataAnnotations;

namespace OfficeApp.Models;

public class Department
{
    [Key]
    public int Id { get; set; }

    [DataType(DataType.Text)]
    [Required]
    [Display(Name = "Department Name")]
    [MinLength(5, ErrorMessage = "Department name must be at least 5 characters long.")]
    [MaxLength(20, ErrorMessage = "Department name cannot exceed 20 characters.")]
    public string Name { get; set; } = string.Empty;
    
 

}
