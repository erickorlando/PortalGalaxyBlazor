using PortalGalaxy.DataAccess;
using PortalGalaxy.Entities;
using PortalGalaxy.Repositories.Interfaces;

namespace PortalGalaxy.Repositories.Implementaciones;

public class InscripcionRepository : RepositoryBase<Inscripcion>, IInscripcionRepository
{
    public InscripcionRepository(PortalGalaxyDbContext context) : base(context)
    {
    }
}