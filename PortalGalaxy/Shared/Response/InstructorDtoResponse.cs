namespace PortalGalaxy.Shared.Response;

public class InstructorDtoResponse
{
    public int Id { get; set; }
    public string Nombres { get; set; } = default!;
    public string NroDocumento { get; set; } = default!;
    public string Categoria { get; set; } = default!;
    public int CategoriaId { get; set; }
}