using System.ComponentModel.DataAnnotations;

namespace PortalGalaxy.Shared.Request;

public class LoginDtoRequest
{
    [Required]
    public string Usuario { get; set; } = default!;

    [Required]
    public string Password { get; set; } = default!;
}