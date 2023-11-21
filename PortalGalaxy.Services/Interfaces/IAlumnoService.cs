using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Interfaces;

public interface IAlumnoService
{
    Task<BaseResponseGeneric<ICollection<AlumnoDtoResponse>>> ListAsync(string? filtro, string? nroDocumento);

    Task<BaseResponseGeneric<AlumnoDtoResponse>> FindByIdAsync(int id);

    Task<BaseResponse> AddAsync(AlumnoDtoRequest request);

    Task<BaseResponse> UpdateAsync(int id, AlumnoDtoRequest request);

    Task<BaseResponse> DeleteAsync(int id);

    Task<BaseResponseGeneric<ICollection<AlumnoDtoResponse>>> ListarEliminadosAsync();

    Task<BaseResponse> ReactivarAsync(int id);
}