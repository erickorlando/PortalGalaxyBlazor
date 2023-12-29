using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalGalaxy.Services.Interfaces;
using PortalGalaxy.Shared;
using PortalGalaxy.Shared.Request;

namespace PortalGalaxy.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InscripcionesController : ControllerBase
{
    private readonly IInscripcionService _service;

    public InscripcionesController(IInscripcionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> ListAsync([FromQuery] BusquedaInscripcionRequest request)
    {
        var response = await _service.ListAsync(request);

        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _service.FindByIdAsync(id);

        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post([FromBody] InscripcionDtoRequest request)
    {
        var response = await _service.AddAsync(User.Identity!.Name!, request);

        return response.Success ? Ok(response) : BadRequest(response);
    }
    
    [HttpPost("masiva")]
    [Authorize(Roles = Constantes.RolAdministrador)]
    public async Task<IActionResult> PostMasiva([FromBody] InscripcionMasivaDtoRequest request)
    {
        var response = await _service.AddMasivaAsync(request);

        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPut("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Put(int id, [FromBody] InscripcionDtoRequest request)
    {
        var response = await _service.UpdateAsync(User.Identity!.Name!, id, request);

        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _service.DeleteAsync(id);

        return response.Success ? Ok(response) : BadRequest(response);
    }

}