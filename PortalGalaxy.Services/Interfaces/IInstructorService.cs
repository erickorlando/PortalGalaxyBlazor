using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Interfaces;

public interface IInstructorService
{
    Task<BaseResponseGeneric<ICollection<InstructorDtoResponse>>> ListAsync(string? filtro);

    Task<BaseResponse> AddAsync(InstructorDtoRequest request);
}