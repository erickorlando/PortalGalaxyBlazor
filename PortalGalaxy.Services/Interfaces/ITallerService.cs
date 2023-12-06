using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Interfaces;

public interface ITallerService
{
    Task<PaginationResponse<TallerDtoResponse>> ListAsync(BusquedaTallerRequest request);
    Task<BaseResponse> AddAsync(TallerDtoRequest request);
    Task<BaseResponseGeneric<TallerDtoRequest>> FindByIdAsync(int id);
    Task<BaseResponse> UpdateAsync(int id, TallerDtoRequest request);
    Task<BaseResponse> DeleteAsync(int id);
}