namespace PortalGalaxy.Shared.Request;

public class BusquedaTallerRequest : RequestBase
{
    public string? Nombre { get; set; }
    public int? CategoriaId { get; set; }
    public int? Situacion { get; set; }
}