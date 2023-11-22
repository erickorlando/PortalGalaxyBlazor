using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Interfaces;

public interface ICategoriaService
{
    Task<BaseResponseGeneric<ICollection<CategoriaDtoResponse>>> ListAsync();

    Task<BaseResponse> DeleteAsync(int id);
}