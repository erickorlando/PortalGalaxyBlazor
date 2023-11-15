using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalGalaxy.Entities;

namespace PortalGalaxy.DataAccess.Configurations;

public class TallerConfiguration : IEntityTypeConfiguration<Taller>
{
    public void Configure(EntityTypeBuilder<Taller> builder)
    {
        builder.Property(p => p.PortadaUrl)
            .IsUnicode(false);
        
        builder.Property(p => p.TemarioUrl)
            .IsUnicode(false);

        builder.Property(p => p.FechaInicio)
            .HasColumnType("DATE");

        builder.Property(p => p.HoraInicio)
            .HasColumnType("DATETIME");

        builder.HasIndex(p => p.Nombre);
    }
}