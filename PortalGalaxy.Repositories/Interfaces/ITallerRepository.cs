using PortalGalaxy.Entities;
using PortalGalaxy.Entities.Infos;

namespace PortalGalaxy.Repositories.Interfaces;

public interface ITallerRepository : IRepositoryBase<Taller>
{
    Task<(ICollection<TallerInfo> Collection, int Total)> ListarTalleresAsync(string? nombre, int? categoriaId, int? situacion, int pagina,
        int filas);
    
    Task<(ICollection<InscritosPorTallerInfo> Colecction, int Total)> ListAsync(int? instructorId, string? taller, int? situacion, DateTime? fechaInicio, DateTime? fechaFin, int pagina, int filas);
}