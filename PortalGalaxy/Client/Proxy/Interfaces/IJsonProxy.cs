using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Proxy.Interfaces;

public interface IJsonProxy
{
    Task<ICollection<DepartamentoModel>> ListDepartamentos();

    Task<ICollection<ProvinciaModel>> ListProvincias(string codDepartamento);

    Task<ICollection<DistritoModel>> ListDistritos(string codProvincia);

    Task<ICollection<SituacionModel>> ListSituaciones();

}