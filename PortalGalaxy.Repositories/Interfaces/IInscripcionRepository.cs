using PortalGalaxy.Entities;
using PortalGalaxy.Entities.Infos;

namespace PortalGalaxy.Repositories.Interfaces;

public interface IInscripcionRepository : IRepositoryBase<Inscripcion>
{
    Task<(ICollection<InscripcionInfo> Colecction, int Total)> ListAsync(int? instructorId, string? taller, int? situacion, DateTime? fechaInicio, DateTime? fechaFin, int pagina, int filas);
}