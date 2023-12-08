using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Interfaces;

public interface ICategoriaService
{
    Task<BaseResponseGeneric<ICollection<CategoriaDtoResponse>>> ListAsync();
    
    Task<BaseResponseGeneric<CategoriaDtoRequest>> FindByIdAsync(int id);
    
    Task<BaseResponse> AddAsync(CategoriaDtoRequest request);
    
    Task<BaseResponse> UpdateAsync(int id, CategoriaDtoRequest request);

    Task<BaseResponse> DeleteAsync(int id);
}