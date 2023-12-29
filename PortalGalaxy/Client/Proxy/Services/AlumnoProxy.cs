using System.Net.Http.Json;
using PortalGalaxy.Client.Proxy.Interfaces;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Proxy.Services;

public class AlumnoProxy : CrudRestHelperBase<AlumnoDtoRequest, AlumnoDtoResponse>, IAlumnoProxy
{
    public AlumnoProxy(HttpClient httpClient) 
        : base("api/Alumnos", httpClient)
    {
    }


    public async Task<ICollection<AlumnoSimpleDtoResponse>> ListarAsync(string? filtro, string? nroDocumento)
    {
        var response = await HttpClient.GetFromJsonAsync<BaseResponseGeneric<ICollection<AlumnoSimpleDtoResponse>>>(
            $"{BaseUrl}/simple?filtro={filtro}&nroDocumento={nroDocumento}");

        if (response is { Success: false })
        {
            throw new InvalidOperationException(response.ErrorMessage);
        }

        return response!.Data;
    }
}