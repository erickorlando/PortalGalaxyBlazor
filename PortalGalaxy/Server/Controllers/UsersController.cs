using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalGalaxy.Services.Interfaces;
using PortalGalaxy.Shared.Request;
using System.Security.Claims;

namespace PortalGalaxy.Server.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;
    private readonly ILogger<UsersController> _logger;

    public UsersController(IUserService service, ILogger<UsersController> logger)
    {
        _service = service;
        _logger = logger;
    }

    // POST: api/Usuarios/Login
    [HttpPost]
    public async Task<IActionResult> Login(LoginDtoRequest request)
    {
        var response = await _service.LoginAsync(request);

        _logger.LogInformation("Se inicio sesion desde {RequestID}", HttpContext.Connection.Id);

        return response.Success ? Ok(response) : Unauthorized(response);
    }

    // POST: api/Usuarios/Register
    [HttpPost]
    public async Task<IActionResult> Register(RegistrarUsuarioDto request)
    {
        var response = await _service.RegisterAsync(request);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> SendTokenToResetPassword(GenerateTokenToResetDtoRequest request)
    {
        return Ok(await _service.SendTokenToResetPasswordAsync(request));
    }

    [HttpPost]
    public async Task<IActionResult> ResetPassword(ResetPasswordDtoRequest request)
    {
        return Ok(await _service.ResetPasswordAsync(request));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> ChangePassword(ChangePasswordDtoRequest request)
    {
        var email = HttpContext.User.Claims.First(p => p.Type == ClaimTypes.Email).Value;

        var response = await _service.ChangePasswordAsync(email, request);

        return Ok(response);
    }
}