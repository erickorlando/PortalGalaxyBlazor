using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Proxy.Interfaces;

public interface ITallerProxy : ICrudRestHelper<TallerDtoRequest, TallerDtoResponse>
{
    Task<PaginationResponse<TallerDtoResponse>> ListAsync(BusquedaTallerRequest request);
    
    Task<PaginationResponse<InscritosPorTallerDtoResponse>> ListAsync(BusquedaInscritosPorTallerRequest request);

    Task<BaseResponseGeneric<ICollection<TallerSimpleDtoResponse>>> ListarAsync();
    
    Task<BaseResponseGeneric<ICollection<TalleresPorMesDto>>> ListarPorMesAsync(int anio);
    
    Task<BaseResponseGeneric<ICollection<TalleresPorInstructorDto>>> ListarPorInstructorAsync(int anio);
}