using System.Net;
using PortalGalaxy.Client.Proxy.Interfaces;
using PortalGalaxy.Shared.Response;
using System.Net.Http.Json;

namespace PortalGalaxy.Client.Proxy.Services;

public class CrudRestHelperBase<TRequest, TResponse> : RestBase, ICrudRestHelper<TRequest, TResponse>
    where TRequest : class
    where TResponse : class
{
    public CrudRestHelperBase(string baseUrl, HttpClient httpClient)
        : base(baseUrl, httpClient)
    {
    }

    public async Task<PaginationResponse<TResponse>> ListAsync(string? filter, int page = 1, int pageSize = 5)
    {
        var response = await HttpClient.GetFromJsonAsync<PaginationResponse<TResponse>>($"{BaseUrl}{filter}");
        if (response!.Success)
        {
            return response;
        }

        throw new InvalidOperationException(response.ErrorMessage);
    }

    public async Task<ICollection<TResponse>> ListAsync()
    {
        var response = await HttpClient.GetFromJsonAsync<PaginationResponse<TResponse>>($"{BaseUrl}");
        if (response!.Success)
        {
            return response.Data!;
        }

        throw new InvalidOperationException(response.ErrorMessage);
    }

    public async Task<TResponse> FindByIdAsync(int id)
    {
        var response = await HttpClient.GetFromJsonAsync<BaseResponseGeneric<TResponse>>($"{BaseUrl}/{id}");
        if (response!.Success)
        {
            return response.Data!;
        }

        throw new InvalidOperationException(response.ErrorMessage);
    }

    public async Task CreateAsync(TRequest request)
    {
        var response = await HttpClient.PostAsJsonAsync(BaseUrl, request);
        var resultado = await response.Content.ReadFromJsonAsync<BaseResponse>();
        if (response.StatusCode == HttpStatusCode.BadRequest)
            throw new InvalidOperationException("No todos los datos fueron ingresados correctamente");
        
        if (resultado is null || resultado.Success == false)
            throw new InvalidOperationException(resultado?.ErrorMessage);
    }

    public async Task UpdateAsync(int id, TRequest request)
    {
        var response = await HttpClient.PutAsJsonAsync($"{BaseUrl}/{id}", request);
        var resultado = await response.Content.ReadFromJsonAsync<BaseResponse>();
        if (resultado!.Success == false)
            throw new InvalidOperationException(resultado.ErrorMessage);
    }

    public async Task DeleteAsync(int id)
    {
        var response = await HttpClient.DeleteAsync($"{BaseUrl}/{id}");
        if (response.IsSuccessStatusCode)
        {
            var resultado = await response.Content.ReadFromJsonAsync<BaseResponse>();
            if (resultado!.Success == false)
                throw new InvalidOperationException(resultado.ErrorMessage);
        }
        else
            throw new InvalidOperationException(response.ReasonPhrase);
    }
}