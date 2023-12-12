using PortalGalaxy.Entities;

namespace PortalGalaxy.Repositories.Interfaces;

public interface IAlumnoRepository : IRepositoryBase<Alumno>
{
    Task Reactivar(int id);

    Task<ICollection<Alumno>> ListarEliminados();

    Task<Alumno?> FindByEmailAsync(string email);
}