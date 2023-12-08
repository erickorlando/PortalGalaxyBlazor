using System.Net.Http.Json;
using PortalGalaxy.Client.Proxy.Interfaces;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Proxy.Services;

public class InstructorProxy : CrudRestHelperBase<InstructorDtoRequest, InstructorDtoResponse>, IInstructorProxy
{
    public InstructorProxy(HttpClient httpClient) 
        : base("api/Instructores", httpClient)
    {
    }


    public async Task<ICollection<InstructorDtoResponse>> ListAsync(string? filtro, string? nroDocumento, int? categoriaId)
    {
        var response = await HttpClient.GetFromJsonAsync<BaseResponseGeneric<ICollection<InstructorDtoResponse>>>($"{BaseUrl}?filtro={filtro}&nroDocumento={nroDocumento}&categoriaId={categoriaId}");
        if (response!.Success)
        {
            return response.Data!;
        }
        

        throw new InvalidOperationException(response.ErrorMessage);
    }
}