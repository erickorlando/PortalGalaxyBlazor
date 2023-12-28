using PortalGalaxy.DataAccess;
using PortalGalaxy.Entities;
using PortalGalaxy.Entities.Infos;
using PortalGalaxy.Repositories.Interfaces;

namespace PortalGalaxy.Repositories.Implementaciones;

public class InscripcionRepository : RepositoryBase<Inscripcion>, IInscripcionRepository
{
    public InscripcionRepository(PortalGalaxyDbContext context) : base(context)
    {
    }

    public async Task<(ICollection<InscripcionInfo> Colecction, int Total)> ListAsync(string? inscrito, string? taller, int? situacion, DateTime? fechaInicio, DateTime? fechaFin, int pagina, int filas)
    {
        var tupla = await ListAsync(predicado: p => p.Alumno.NombreCompleto.Contains(inscrito ?? string.Empty)
                                                    && (p.Taller.Nombre.Contains(taller ?? string.Empty))
                                                    && (situacion == null ||
                                                        p.Situacion == (SituacionInscripcion)situacion)
                            && (fechaInicio == null || fechaInicio <= p.FechaCreacion && fechaFin >= p.FechaCreacion),
            selector: p => new InscripcionInfo
            {
                Id = p.Id,
                Nombre = p.Alumno.NombreCompleto,
                Taller = p.Taller.Nombre,
                Fecha = p.FechaCreacion.ToString("dd/MM/yyyy"),
                Situacion = p.Situacion.ToString().Replace('_',' ')
            }, 
            orderBy: x => x.Id,
            relaciones: "Alumno,Taller",
            pagina: pagina,
            filas: filas);

        return tupla;
        
        
    }
}