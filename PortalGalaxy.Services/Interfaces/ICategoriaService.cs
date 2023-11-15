using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Interfaces;

public interface ICategoriaService
{
    Task<BaseResponseGeneric<ICollection<CategoriaDtoResponse>>> ListAsync();
}