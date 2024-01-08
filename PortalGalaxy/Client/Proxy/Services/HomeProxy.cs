using System.Net.Http.Json;
using PortalGalaxy.Client.Proxy.Interfaces;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Proxy.Services;

public class HomeProxy : RestBase, IHomeProxy
{
    public HomeProxy(HttpClient httpClient) 
        : base("api/Home", httpClient)
    {
    }

    public async Task<PaginationResponse<TallerHomeDtoResponse>> ListarTalleresHomeAsync(BusquedaTallerHomeRequest request)
    {
        var fechaInicio = request.FechaInicio?.ToString("yyyy-MM-dd");
        // Agregar un dia mas al final para que tome la fecha completa
        request.FechaFin = request.FechaFin?.AddDays(1);
        var fechaFin = request.FechaFin?.ToString("yyyy-MM-dd");
        
        var response = await HttpClient.GetFromJsonAsync<PaginationResponse<TallerHomeDtoResponse>>($"{BaseUrl}?Nombre={request.Nombre}&InstructorId={request.InstructorId}&FechaInicio={fechaInicio}&FechaFin={fechaFin}&Pagina={request.Pagina}&Filas={request.Filas}");
        
        if (response is { Success: false })
            throw new ApplicationException(response.ErrorMessage);
        
        return response!;
    }

    public async Task<BaseResponseGeneric<TallerHomeDtoResponse>> GetTallerHomeAsync(int id)
    {
        var response = await HttpClient.GetFromJsonAsync<BaseResponseGeneric<TallerHomeDtoResponse>>($"{BaseUrl}/{id}");
        
        if (response is { Success: false })
            throw new ApplicationException(response.ErrorMessage);
        
        return response!;
    }
}