namespace PortalGalaxy.Shared.Response;

public class InscritosPorTallerDtoResponse
{
    public int Id { get; set; }
    public string Taller { get; set; } = default!;
    public string Categoria { get; set; } = default!;
    public string Instructor { get; set; } = default!;
    public string Fecha { get; set; } = default!;
    public string Situacion { get; set; } = default!;
    public int Cantidad { get; set; }
}