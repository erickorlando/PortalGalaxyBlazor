namespace PortalGalaxy.Shared.Response;

public class AlumnoSimpleDtoResponse
{
    public int Id { get; set; }
    public string NroDocumento { get; set; } = default!;
    public string NombreCompleto { get; set; } = default!;
    public string FechaRegistro { get; set; } = default!;
    public bool Seleccionado { get; set; }
}