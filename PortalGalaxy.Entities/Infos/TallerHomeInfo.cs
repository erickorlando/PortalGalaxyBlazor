namespace PortalGalaxy.Entities.Infos;

public class TallerHomeInfo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = default!;
    public DateTime FechaInicio { get; set; }
    public DateTime HoraInicio { get; set; }
    public string? PortadaUrl { get; set; }
    public string? TemarioUrl { get; set; }
    public string? Descripcion { get; set; }
    public string Instructor { get; set; } = default!;
}