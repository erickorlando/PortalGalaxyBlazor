using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PortalGalaxy.DataAccess;
using PortalGalaxy.Entities;
using PortalGalaxy.Repositories.Interfaces;
using PortalGalaxy.Services.Interfaces;
using PortalGalaxy.Shared;
using PortalGalaxy.Shared.Configuracion;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;

namespace PortalGalaxy.Services.Implementaciones;

public class UserService : IUserService
{
    private readonly UserManager<GalaxyIdentityUser> _userManager;
    private readonly ILogger<UserService> _logger;
    private readonly IOptions<AppSettings> _options;
    private readonly IAlumnoRepository _alumnoRepository;

    public UserService(UserManager<GalaxyIdentityUser> userManager,
        ILogger<UserService> logger,
        IOptions<AppSettings> options,
        IAlumnoRepository alumnoRepository)
    {
        _userManager = userManager;
        _logger = logger;
        _options = options;
        _alumnoRepository = alumnoRepository;
    }

    public async Task<LoginDtoResponse> LoginAsync(LoginDtoRequest request)
    {
        var response = new LoginDtoResponse();

        try
        {
            var identity = await _userManager.FindByNameAsync(request.Usuario);

            if (identity is null)
                throw new SecurityException("Usuario no existe");

            if (await _userManager.IsLockedOutAsync(identity))
            {
                throw new SecurityException($"Demasiados intentos fallidos para el usuario {request.Usuario}");
            }

            if (!await _userManager.CheckPasswordAsync(identity, request.Password))
            {
                response.ErrorMessage = "Clave incorrecta";
                _logger.LogWarning($"Intento fallido de Login para el usuario {identity.UserName}");
                await _userManager.AccessFailedAsync(identity);

                return response;
            }

            var roles = await _userManager.GetRolesAsync(identity);

            var fechaExpiracion = DateTime.Now.AddDays(1);

            // Vamos a crear los claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, identity.NombreCompleto),
                new Claim(ClaimTypes.Email, identity.Email!),
                new Claim(ClaimTypes.Expiration, fechaExpiracion.ToLongDateString()),
            };

            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));

            // Creamos el JWT
            var llaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.Jwt.SecretKey));
            var credenciales = new SigningCredentials(llaveSimetrica, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(credenciales);

            var payload = new JwtPayload(
                issuer: _options.Value.Jwt.Emisor,
                audience: _options.Value.Jwt.Audiencia,
                notBefore: DateTime.Now,
                claims: claims,
                expires: fechaExpiracion);

            var token = new JwtSecurityToken(header, payload);
            response.Token = new JwtSecurityTokenHandler().WriteToken(token);
            response.NombresCompletos = identity.NombreCompleto;
            response.Success = true;


            _logger.LogInformation("Se creó el JWT de forma satisfactoria");
        }
        catch (SecurityException ex)
        {
            response.ErrorMessage = ex.Message;
            _logger.LogError(ex, "Error de seguridad {Message}", ex.Message);
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error de autenticacion";
            _logger.LogCritical(ex, "Error al autenticar {Message}", ex.Message);
        }

        return response;
    }

    public async Task<BaseResponse> RegisterAsync(RegistrarUsuarioDto request)
    {
        var response = new BaseResponse();
        try
        {
            var user = new GalaxyIdentityUser()
            {
                NombreCompleto = request.NombresCompleto,
                UserName = request.Usuario,
                Email = request.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Constantes.RolAlumno);


                var alumno = new Alumno
                {
                    NombreCompleto = request.NombresCompleto,
                    Correo = request.Email,
                    Telefono = request.Telefono,
                    NroDocumento = request.NroDocumento,
                    Departamento = request.CodigoDepartamento,
                    Provincia = request.CodigoProvincia,
                    Distrito = request.CodigoDistrito
                };

                await _alumnoRepository.AddAsync(alumno);

                // TODO: Enviar un email
            }
            else
            {
                var sb = new StringBuilder();
                foreach (var identityError in result.Errors)
                {
                    sb.AppendFormat("{0} ", identityError.Description);
                }

                response.ErrorMessage = sb.ToString();
                sb.Clear();
            }

            response.Success = result.Succeeded;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al registrar";
            _logger.LogWarning(ex, "{MensajeError} {Message}", response.ErrorMessage, ex.Message);
        }
        return response;
    }
}