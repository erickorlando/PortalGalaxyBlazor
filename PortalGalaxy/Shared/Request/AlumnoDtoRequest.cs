namespace PortalGalaxy.Shared.Request;

public class AlumnoDtoRequest
{
    public string NroDocumento { get; set; } = default!;
    public string NombreCompleto { get; set; } = default!;
    public string Correo { get; set; } = default!;
    public string? Telefono { get; set; }
    public string Departamento { get; set; } = default!;
    public string Provincia { get; set; } = default!;
    public string Distrito { get; set; } = default!;
}