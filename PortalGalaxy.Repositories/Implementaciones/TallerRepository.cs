using System.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;
using PortalGalaxy.DataAccess;
using PortalGalaxy.Entities;
using PortalGalaxy.Entities.Infos;
using PortalGalaxy.Repositories.Interfaces;

namespace PortalGalaxy.Repositories.Implementaciones;

public class TallerRepository : RepositoryBase<Taller>, ITallerRepository
{
    public TallerRepository(PortalGalaxyDbContext context) : base(context)
    {
    }

    public async Task<(ICollection<TallerInfo> Collection, int Total)> ListarTalleresAsync(string? nombre, int? categoriaId, int? situacion, int pagina, int filas)
    {
        var tupla = await ListAsync(predicado: p => p.Nombre.Contains(nombre ?? string.Empty)
                                                    && (categoriaId == null || p.CategoriaId == categoriaId)
                                                    && (situacion == null ||
                                                        p.Situacion == (SituacionTaller)situacion),
                                    selector: p => new TallerInfo
                                    {
                                        Id = p.Id,
                                        Nombre = p.Nombre,
                                        Categoria = p.Categoria.Nombre,
                                        Fecha = p.FechaInicio,
                                        Instructor = p.Instructor.Nombres,
                                        Situacion = p.Situacion.ToString().Replace('_',' ')
                                    }, 
                                    orderBy: x => x.Id,
                                    relaciones: "Categoria,Instructor",
                                    pagina: pagina,
                                    filas: filas);

        return tupla;
    }

    public async Task<(ICollection<InscritosPorTallerInfo> Colecction, int Total)> ListAsync(int? instructorId, string? taller, int? situacion, DateTime? fechaInicio, DateTime? fechaFin, int pagina,
        int filas)
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
            var collection = multipleQuery.Read<InscritosPorTallerInfo>().ToList();
            var total = multipleQuery.ReadFirst<int>();

            return (collection, total);
        }
        catch (Exception)
        {
            return (new List<InscritosPorTallerInfo>(), 0);
        }
    }
}