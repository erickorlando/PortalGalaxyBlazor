namespace PortalGalaxy.Shared.Response;

public class LoginDtoResponse : BaseResponse
{
    public string NombresCompletos { get; set; } = default!;
    public string Token { get; set; } = default!;

    public List<string> Roles { get; set; } = default!;
}