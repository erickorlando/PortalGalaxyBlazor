using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Proxy.Interfaces;

public interface IHomeProxy
{
    Task<PaginationResponse<TallerHomeDtoResponse>> ListarTalleresHomeAsync(BusquedaTallerHomeRequest request);
}