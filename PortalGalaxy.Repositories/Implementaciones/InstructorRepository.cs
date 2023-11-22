using Microsoft.EntityFrameworkCore;
using PortalGalaxy.DataAccess;
using PortalGalaxy.Entities;
using PortalGalaxy.Entities.Infos;
using PortalGalaxy.Repositories.Interfaces;
using System.Linq.Expressions;

namespace PortalGalaxy.Repositories.Implementaciones;

public class InstructorRepository : RepositoryBase<Instructor>, IInstructorRepository
{
    public InstructorRepository(PortalGalaxyDbContext context) : base(context)
    {
    }

    public async Task<ICollection<InstructorInfo>> ListAsync(string? nombre, string? nroDocumento, int? categoriaId)
    {
        Expression<Func<Instructor, bool>> predicate
            = x => x.Nombres.Contains(nombre ?? string.Empty)
                   && (string.IsNullOrEmpty(nroDocumento) || x.NroDocumento.Equals(nroDocumento))
                   && (categoriaId == null || x.CategoriaId.Equals(categoriaId));


        return await Context.Set<Instructor>()
            .Where(predicate)
            .IgnoreQueryFilters()
            .Select(p => new InstructorInfo
            {
                Id = p.Id,
                Nombres = p.Nombres,
                NroDocumento = p.NroDocumento,
                Categoria = p.Categoria.Nombre, // Lazy Loading - EF Core
                CategoriaId = p.CategoriaId
            })
            .ToListAsync();
    }
}