using PortalGalaxy.DataAccess;
using PortalGalaxy.Entities;
using PortalGalaxy.Repositories.Interfaces;

namespace PortalGalaxy.Repositories.Implementaciones;

public class AlumnoRepository : RepositoryBase<Alumno>, IAlumnoRepository
{
    public AlumnoRepository(PortalGalaxyDbContext context) 
        : base(context)
    {
    }
}