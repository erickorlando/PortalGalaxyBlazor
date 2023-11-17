namespace PortalGalaxy.Shared.Request;

public class GenerateTokenToResetDtoRequest
{
    public string Usuario { get; set; } = default!;
    public string Email { get; set; } = default!;
}