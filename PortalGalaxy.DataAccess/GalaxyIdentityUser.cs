using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PortalGalaxy.DataAccess;

public class GalaxyIdentityUser : IdentityUser
{
    [StringLength(100)]
    public string NombreCompleto { get; set; } = default!;
}