using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Auth;

public class AuthenticationService : AuthenticationStateProvider
{
    private readonly ISessionStorageService _sessionStorageService;
    private readonly HttpClient _httpClient;
    private readonly ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

    public AuthenticationService(ISessionStorageService sessionStorageService, HttpClient httpClient)
    {
        _sessionStorageService = sessionStorageService;
        _httpClient = httpClient;
    }

    public async Task Authenticate(LoginDtoResponse? response)
    {
        ClaimsPrincipal claimsPrincipal;

        if (response is not null)
        {
            // Establecemos al objeto HttpClient el token en el header
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", response.Token);

            // Recuperamos los claims desde el token recibido.
            var jwt = ParseToken(response);

            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(jwt.Claims, authenticationType: "JWT"));

            // Guardamos la sesion
            await _sessionStorageService.SetItemAsync("sesion", response);
        }
        else
        {
            claimsPrincipal = _anonymous;
            await _sessionStorageService.RemoveItemAsync("sesion");
        }

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }

    private JwtSecurityToken ParseToken(LoginDtoResponse response)
    {
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(response.Token);
        return token;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var sesionUsuario = await _sessionStorageService.GetItemAsync<LoginDtoResponse>("sesion");

        if (sesionUsuario is null)
            return await Task.FromResult(new AuthenticationState(_anonymous));

        var claimsPrincipal =
            new ClaimsPrincipal(new ClaimsIdentity(ParseToken(sesionUsuario).Claims, authenticationType: "JWT"));

        return await Task.FromResult(new AuthenticationState(claimsPrincipal));
    }
}