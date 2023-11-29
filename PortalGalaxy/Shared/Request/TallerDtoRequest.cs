namespace PortalGalaxy.Shared.Request;

public class TallerDtoRequest
{
    public string Nombre { get; set; } = default!;

    public int CategoriaId { get; set; }

    public int InstructorId { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime HoraInicio { get; set; }
    public int Situacion { get; set; }
    public string? Base64Portada { get; set; }
    public string? Base64Temario { get; set; }
    public string? PortadaUrl { get; set; }
    public string? TemarioUrl { get; set; }
    public string? ArchivoPortada { get; set; }
    public string? ArchivoTemario { get; set; }
}