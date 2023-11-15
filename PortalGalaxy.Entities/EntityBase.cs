namespace PortalGalaxy.Entities;

public class EntityBase
{
    public int Id { get; set; }
    public bool Estado { get; set; }
    public DateTime FechaCreacion { get; set; }

    protected EntityBase()
    {
        Estado = true;
        FechaCreacion = DateTime.UtcNow;
    }
}