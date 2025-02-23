using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Frontend.Models.Base;

namespace Frontend.Models;

public class User : BaseModel
{

    [Required(ErrorMessage = "Name is required")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    [MinLength(3)]
    public string Email { get; set; } 
}