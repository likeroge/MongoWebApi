using System.ComponentModel.DataAnnotations;

namespace Frontend.Models.DTO;

public class CreateUserDto
{
    [Required(ErrorMessage = "Name is required")]
    [MinLength(3)]
    public string Name { get; set; }
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    [MinLength(3)]
    public string Email { get; set; }
}