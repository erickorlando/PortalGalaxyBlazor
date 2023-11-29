namespace PortalGalaxy.Entities.Infos;

public class TallerInfo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = default!;
    public string Categoria { get; set; } = default!;
    public string Instructor { get; set; } = default!;
    public DateTime Fecha { get; set; }
    public string Situacion { get; set; } = default!;

}