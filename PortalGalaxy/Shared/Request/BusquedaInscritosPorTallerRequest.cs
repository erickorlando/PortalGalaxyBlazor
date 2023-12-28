namespace PortalGalaxy.Shared.Request;

public class BusquedaInscritosPorTallerRequest : RequestBase
{
    public string? Instructor { get; set; }
    public int? InstructorId { get; set; }
    public string? Taller { get; set; }
    public int? Situacion { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }

}