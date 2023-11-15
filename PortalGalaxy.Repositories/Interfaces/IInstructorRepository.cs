using PortalGalaxy.Entities;

namespace PortalGalaxy.Repositories.Interfaces;

public interface IInstructorRepository : IRepositoryBase<Instructor>
{
    Task<ICollection<Instructor>> ListarAsync(string? filtro);
}