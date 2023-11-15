using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace PortalGalaxy.DataAccess
{
    public class PortalGalaxyDbContext : DbContext
    {
        public PortalGalaxyDbContext(DbContextOptions<PortalGalaxyDbContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<string>()
                .HaveMaxLength(100);

            configurationBuilder.Conventions.Remove(typeof(CascadeDeleteConvention));
        }
    }
}