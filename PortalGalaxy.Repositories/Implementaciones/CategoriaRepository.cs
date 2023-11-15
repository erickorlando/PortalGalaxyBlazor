using PortalGalaxy.DataAccess;
using PortalGalaxy.Entities;
using PortalGalaxy.Repositories.Interfaces;

namespace PortalGalaxy.Repositories.Implementaciones;

public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(PortalGalaxyDbContext context) : base(context)
    {
    }
}