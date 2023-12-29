namespace PortalGalaxy.Shared.Request;

public class InscripcionMasivaDtoRequest : InscripcionDtoRequest
{
    public ICollection<int> Inscritos { get; set; } = new List<int>();
}