using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Proxy.Interfaces;

public interface IInstructorProxy : ICrudRestHelper<InstructorDtoRequest, InstructorDtoResponse>
{
    Task<ICollection<InstructorDtoResponse>> ListAsync(string? filtro, string? nroDocumento, int? categoriaId);
}