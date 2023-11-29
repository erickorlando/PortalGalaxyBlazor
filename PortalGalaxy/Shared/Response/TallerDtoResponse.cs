namespace PortalGalaxy.Shared.Response;

public class TallerDtoResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; } = default!;
    public string Categoria { get; set; } = default!;
    public string Instructor { get; set; } = default!;
    public string Fecha { get; set; } = default!;
    public string Situacion { get; set; } = default!;
}