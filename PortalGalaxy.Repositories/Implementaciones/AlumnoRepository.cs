using Microsoft.EntityFrameworkCore;
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

    public async Task<ICollection<Alumno>> ListarEliminados()
    {
        return await Context.Set<Alumno>()
            .IgnoreQueryFilters() // Ignoramos el query filter global
            .Where(p => !p.Estado)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task Reactivar(int id)
    {
        var registro = await Context.Set<Alumno>()
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(p => p.Id == id);

        if (registro is not null)
        {
            registro.Estado = true;
            await UpdateAsync();
        }
    }
}