using System.ComponentModel.DataAnnotations;

namespace FilmFlicks.Controllers.Requests;

public class UserRequest
{
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
}