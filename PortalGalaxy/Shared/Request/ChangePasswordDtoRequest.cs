using System.ComponentModel.DataAnnotations;

namespace PortalGalaxy.Shared.Request;

public class ChangePasswordDtoRequest
{
    [Required]
    public string ClaveAnterior { get; set; } = default!;

    [Required]
    public string Clave { get; set; } = default!;
    
    [Compare(nameof(Clave))]
    public string ConfirmarClave { get; set; } = default!;
}