using PortalGalaxy.DataAccess;
using PortalGalaxy.Entities;
using PortalGalaxy.Repositories.Interfaces;

namespace PortalGalaxy.Repositories.Implementaciones;

public class TallerRepository : RepositoryBase<Taller>, ITallerRepository
{
    public TallerRepository(PortalGalaxyDbContext context) : base(context)
    {
    }
}