using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Interfaces;

public interface IInstructorService
{
    Task<BaseResponseGeneric<ICollection<InstructorDtoResponse>>> ListAsync(string? filtro, string? nroDocumento, int? categoriaId);

    Task<BaseResponse> AddAsync(InstructorDtoRequest request);
    Task<BaseResponseGeneric<InstructorDtoResponse>> FindByIdAsync(int id);
    Task<BaseResponse> UpdateAsync(int id, InstructorDtoRequest request);
    Task<BaseResponse> DeleteAsync(int id);
}