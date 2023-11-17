using System.ComponentModel.DataAnnotations;

namespace PortalGalaxy.Shared.Request;

public class ResetPasswordDtoRequest
{
    [Required]
    public string Token { get; set; } = default!;
    [Required]
    public string Email { get; set; } = default!;
    
    [Required]
    public string Clave { get; set; } = default!;
    [Compare(nameof(Clave))]
    public string ConfirmarClave { get; set; } = default!;
}