using System.ComponentModel.DataAnnotations;

namespace Validation.Models;

public class CreateUserModel
{
    [Required]
    public string Username { get; set; }
    public string Password { get; set; }
    public decimal Salary { get; set; }
    public string Email { get; set; }
}