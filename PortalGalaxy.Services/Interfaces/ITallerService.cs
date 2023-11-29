using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Interfaces;

public interface ITallerService
{
    Task<BaseResponse> AddAsync(TallerDtoRequest request);

    Task<PaginationResponse<TallerDtoResponse>> ListAsync(BusquedaTallerRequest request);
}