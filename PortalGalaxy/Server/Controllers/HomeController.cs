using Microsoft.AspNetCore.Mvc;
using PortalGalaxy.Services.Interfaces;
using PortalGalaxy.Shared.Request;

namespace PortalGalaxy.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private readonly ITallerService _tallerService;

    public HomeController(ITallerService tallerService)
    {
        _tallerService = tallerService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] BusquedaTallerHomeRequest request)
    {
        if (request.Pagina <= 0)
            request.Pagina = 1;
        if (request.Filas <= 0)
            request.Filas = 5;
        
        var response = await _tallerService.ListarTalleresHomeAsync(request);
        return Ok(response);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _tallerService.GetTallerHomeAsync(id);
        return Ok(response);
    }
}