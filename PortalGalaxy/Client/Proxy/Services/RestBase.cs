using PortalGalaxy.Shared.Response;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace PortalGalaxy.Client.Proxy.Services;

public abstract class RestBase
{
    protected readonly HttpClient HttpClient;

    protected string BaseUrl { get; set; }

    protected RestBase(string baseUrl, HttpClient httpClient)
    {
        BaseUrl = baseUrl;
        HttpClient = httpClient;
    }

    protected async Task<TOutput> SendAsync<TInput, TOutput>(TInput request, HttpMethod method, string url)
        where TOutput : BaseResponse
    {
        var requestMessage = new HttpRequestMessage(method, $"{BaseUrl}/{url}");
        requestMessage.Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8,
            MediaTypeNames.Application.Json);

        var response = await HttpClient.SendAsync(requestMessage);

        if (!response.IsSuccessStatusCode)
        {
            var errorResponse = await response.Content.ReadFromJsonAsync<TOutput>();
            return errorResponse!;
        }

        var result = await response.Content.ReadFromJsonAsync<TOutput>();
        if (result != null)
        {
            return result;
        }

        throw new InvalidOperationException($"Error en la solicitud {url}");
    }
}