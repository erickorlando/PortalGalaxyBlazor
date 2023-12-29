namespace PortalGalaxy.Shared.Request;

public class BusquedaTallerHomeRequest : RequestBase
{
    public string? Nombre { get; set; }
    public int? InstructorId { get; set; }
    public DateTime? FechaInicio { get; set; } 
    public DateTime? FechaFin { get; set; } 
}