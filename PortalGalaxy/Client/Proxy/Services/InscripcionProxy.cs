using System.Net.Http.Json;
using PortalGalaxy.Client.Proxy.Interfaces;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Proxy.Services;

public class InscripcionProxy : CrudRestHelperBase<InscripcionDtoRequest, InscripcionDtoResponse>, IInscripcionProxy
{
    public InscripcionProxy(HttpClient httpClient)
        : base("api/Inscripciones", httpClient)
    {
    }

    public async Task<PaginationResponse<InscripcionDtoResponse>> ListAsync(BusquedaInscripcionRequest request)
    {
        var response = await HttpClient.GetFromJsonAsync<PaginationResponse<InscripcionDtoResponse>>(
            $"{BaseUrl}?inscrito={request.Inscrito}&taller={request.Taller}&situacion={request.Situacion}&fechaInicio={request.FechaInicio}&fechaFin={request.FechaFin}&pagina={request.Pagina}&filas={request.Filas}");

        if (response is { Success: false })
        {
            throw new InvalidOperationException(response.ErrorMessage);
        }

        return response!;
    }
}