using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PortalGalaxy.Shared;

namespace PortalGalaxy.DataAccess;

public static class UserDataSeeder
{
    public static async Task Seed(IServiceProvider service)
    {
        // UserManager (Repositorio de Usuarios)
        var userManager = service.GetRequiredService<UserManager<GalaxyIdentityUser>>();
        // RoleManager (Repositorio de Roles)
        var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

        // Crear roles
        var adminRole = new IdentityRole(Constantes.RolAdministrador);
        var alumnoRole = new IdentityRole(Constantes.RolAlumno);

        await roleManager.CreateAsync(adminRole);

        await roleManager.CreateAsync(alumnoRole);

        // Usuario Administrador
        var adminUser = new GalaxyIdentityUser()
        {
            NombreCompleto = "Administrador del sistema",
            UserName = "admin",
            Email = "admin@gmail.com",
            PhoneNumber = "+1 999 999 999",
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(adminUser, "pa$$W0rD@123");
        if (result.Succeeded)
        {
            // Esto me asegura que el usuario se creo correctamente
            adminUser = await userManager.FindByEmailAsync(adminUser.Email);
            if (adminUser is not null)
                await userManager.AddToRoleAsync(adminUser, Constantes.RolAdministrador);
        }
    }
}