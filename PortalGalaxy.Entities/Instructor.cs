namespace PortalGalaxy.Entities;

public class Instructor : EntityBase
{
    public string Nombres { get; set; } = default!;
    public string NroDocumento { get; set; } = default!;
    public Categoria Categoria { get; set; } = default!;
    public int CategoriaId { get; set; }
    
}