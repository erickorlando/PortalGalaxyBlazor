using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PortalGalaxy.DataAccess;

public class ApplicationDbContext : IdentityDbContext<GalaxyIdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):
        base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<GalaxyIdentityUser>(e =>
        {
            e.ToTable("Usuario");
            e.Property(p => p.LockoutEnd).HasColumnName("BloqueoHasta");
        });
        builder.Entity<IdentityRole>(e => e.ToTable("Rol"));
        builder.Entity<IdentityUserRole<string>>(e => e.ToTable("UsuarioRol"));
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<string>().HaveMaxLength(150);
    }
}