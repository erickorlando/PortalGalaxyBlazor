using System.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;
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

    public async Task<(ICollection<InscripcionInfo> Colecction, int Total)> ListAsync(int? instructorId, string? taller, int? situacion, DateTime? fechaInicio, DateTime? fechaFin, int pagina, int filas)
    {
        await using var multipleQuery = await Context.Database.GetDbConnection()
            .QueryMultipleAsync(
            sql: "uspListarInscripciones", 
            commandType: CommandType.StoredProcedure, 
            param: new
        {
            instructorId,
            taller,
            situacion,
            fechaInicio,
            fechaFin,
            pagina = pagina - 1,
            filas
        });

        try
        {
            var collection = multipleQuery.Read<InscripcionInfo>().ToList();
            var total = multipleQuery.ReadFirst<int>();

            return (collection, total);
        }
        catch (Exception)
        {
            return (new List<InscripcionInfo>(), 0);
        }
    }
}