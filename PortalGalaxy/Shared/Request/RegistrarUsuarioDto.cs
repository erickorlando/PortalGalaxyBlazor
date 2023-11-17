using System.ComponentModel.DataAnnotations;

namespace PortalGalaxy.Shared.Request;

public class RegistrarUsuarioDto
{
    [Required]
    public string Usuario { get; set; } = default!;

    [Required]
    public string NombresCompleto { get; set; } = default!;

    [EmailAddress]
    public string Email { get; set; } = default!;

    [Required]
    public string Telefono { get; set; } = default!;

    [Required]
    public string NroDocumento { get; set; } = default!;

    [Required]
    public string Password { get; set; } = default!;
    
    [Compare(nameof(Password))]
    public string ConfirmarPassword { get; set; } = default!;

    public string CodigoDepartamento { get; set; } = default!;
    public string CodigoProvincia { get; set; } = default!;
    public string CodigoDistrito { get; set; } = default!;
}