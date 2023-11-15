using Microsoft.EntityFrameworkCore;
using PortalGalaxy.DataAccess;
using PortalGalaxy.Entities;
using PortalGalaxy.Repositories.Interfaces;

namespace PortalGalaxy.Repositories.Implementaciones;

public class InstructorRepository : RepositoryBase<Instructor>, IInstructorRepository
{
    public InstructorRepository(PortalGalaxyDbContext context) : base(context)
    {
    }

    public async Task<ICollection<Instructor>> ListarAsync(string? filtro)
    {
        return await Context.Set<Instructor>()
            .Include(p => p.Categoria)
            .Where(p => p.Nombres.Contains(filtro ?? string.Empty))
            .AsNoTracking()
            .ToListAsync();
    }
}