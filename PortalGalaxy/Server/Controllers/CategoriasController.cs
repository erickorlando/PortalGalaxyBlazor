using Microsoft.AspNetCore.Mvc;
using PortalGalaxy.Services.Interfaces;

namespace PortalGalaxy.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _service;

    public CategoriasController(ICategoriaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _service.ListAsync();

        return Ok(response);
    }

}