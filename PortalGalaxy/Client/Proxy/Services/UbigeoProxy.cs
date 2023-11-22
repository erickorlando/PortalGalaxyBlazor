using System.Net.Http.Json;
using PortalGalaxy.Client.Proxy.Interfaces;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Proxy.Services;

public class UbigeoProxy : IUbigeoProxy
{
    private readonly HttpClient _httpClient;

    public UbigeoProxy(HttpClient httpClient)
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
}