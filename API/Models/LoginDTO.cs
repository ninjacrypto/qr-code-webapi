using System.ComponentModel.DataAnnotations;

namespace API.Models;

public sealed class LoginDTO
{
    public LoginDTO()
    {

    }

    [Required(ErrorMessage = "No name.")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "No password.")]
    public string Password { get; set; }
}
