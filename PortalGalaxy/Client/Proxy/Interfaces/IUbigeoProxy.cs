using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Proxy.Interfaces;

public interface IUbigeoProxy
{
    Task<ICollection<DepartamentoModel>> ListDepartamentos();

    Task<ICollection<ProvinciaModel>> ListProvincias(string codDepartamento);

    Task<ICollection<DistritoModel>> ListDistritos(string codProvincia);
}