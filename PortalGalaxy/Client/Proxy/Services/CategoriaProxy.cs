using PortalGalaxy.Client.Proxy.Interfaces;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Proxy.Services;

public class CategoriaProxy : CrudRestHelperBase<CategoriaDtoRequest, CategoriaDtoResponse>, ICategoriaProxy
{
    public CategoriaProxy(HttpClient httpClient) 
        : base("api/categorias", httpClient)
    {
    }
}