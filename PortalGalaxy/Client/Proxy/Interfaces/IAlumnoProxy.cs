using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Proxy.Interfaces;

public interface IAlumnoProxy : ICrudRestHelper<AlumnoDtoRequest, AlumnoDtoResponse>
{
    Task<ICollection<AlumnoSimpleDtoResponse>> ListarAsync(string? filtro, string? nroDocumento);
}