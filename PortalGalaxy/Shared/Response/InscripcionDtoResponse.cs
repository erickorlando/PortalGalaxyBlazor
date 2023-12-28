namespace PortalGalaxy.Shared.Response;

public class InscripcionDtoResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; } = default!;
    public string Taller { get; set; } = default!;
    public string Fecha { get; set; } = default!;
    public string Situacion { get; set; } = default!;
}