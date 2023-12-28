namespace PortalGalaxy.Shared.Request;

public class BusquedaInscripcionRequest : RequestBase
{
    public string? Inscrito { get; set; }
    public string? Taller { get; set; }
    public int? Situacion { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }

}