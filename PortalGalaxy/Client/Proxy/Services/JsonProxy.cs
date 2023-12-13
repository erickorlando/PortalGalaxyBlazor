using System.Net.Http.Json;
using PortalGalaxy.Client.Proxy.Interfaces;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Proxy.Services;

public class JsonProxy : IJsonProxy
{
    private readonly HttpClient _httpClient;

    public JsonProxy(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ICollection<DepartamentoModel>> ListDepartamentos()
    {
        var departamentos = await _httpClient.GetFromJsonAsync<List<DepartamentoModel>>("data/departamentos.json") ??
                            new();

        return departamentos;
    }

    public async Task<ICollection<ProvinciaModel>> ListProvincias(string codDepartamento)
    {
        var provincias = await _httpClient.GetFromJsonAsync<List<ProvinciaModel>>("data/provincias.json") ?? new();

        return provincias.Where(p => p.CodigoDpto == codDepartamento).ToList();
    }

    public async Task<ICollection<DistritoModel>> ListDistritos(string codProvincia)
    {
        var distritos = await _httpClient.GetFromJsonAsync<List<DistritoModel>>("data/distritos.json") ?? new();

        return distritos.Where(p => p.CodProvincia == codProvincia).ToList();
    }

    public async Task<ICollection<SituacionModel>> ListSituaciones()
    {
        var situaciones = await _httpClient.GetFromJsonAsync<List<SituacionModel>>("data/situaciones.json") ?? new();

        return situaciones;
    }

}