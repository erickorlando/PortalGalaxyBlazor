using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalGalaxy.Entities;

namespace PortalGalaxy.DataAccess.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        // Data Seeding

        var fecha = DateTime.Parse("2023-08-01");

        builder.HasData(new List<Categoria>
        {
            new() { Id = 1, Nombre = ".NET", FechaCreacion = fecha, Hora = Convert.ToDateTime("2023-12-02 19:00:00") },
            new() { Id = 2, Nombre = "Java", FechaCreacion = fecha, Hora = Convert.ToDateTime("2023-12-02 20:00:00") },
            new() { Id = 3, Nombre = "AWS", FechaCreacion = fecha, Hora = Convert.ToDateTime("2023-12-02 21:00:00") },
            new() { Id = 4, Nombre = "Azure", FechaCreacion = fecha, Hora = Convert.ToDateTime("2023-12-02 22:00:00") },
            new() { Id = 5, Nombre = "Python", FechaCreacion = fecha, Hora = Convert.ToDateTime("2023-12-02 23:00:00") },
        });

        builder.HasQueryFilter(p => p.Estado);
    }
}