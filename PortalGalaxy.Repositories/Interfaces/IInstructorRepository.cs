using PortalGalaxy.Entities;
using PortalGalaxy.Entities.Infos;

namespace PortalGalaxy.Repositories.Interfaces;

public interface IInstructorRepository : IRepositoryBase<Instructor>
{
    Task<ICollection<InstructorInfo>> ListAsync(string? nombre, string? nroDocumento, int? categoriaId);
}