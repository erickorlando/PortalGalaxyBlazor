namespace PortalGalaxy.Shared.Response;

public class DepartamentoModel
{
    public string Codigo { get; set; } = default!;
    public string Nombre { get; set; } = default!;
}

public class ProvinciaModel
{
    public string CodigoDpto { get; set; } = default!;
    public string Codigo { get; set; } = default!;
    public string Nombre { get; set; } = default!;
}

public class DistritoModel
{
    public string CodProvincia { get; set; } = default!;
    public string Codigo { get; set; } = default!;
    public string Nombre { get; set; } = default!;

}