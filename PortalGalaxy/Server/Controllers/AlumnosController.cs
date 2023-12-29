using Microsoft.AspNetCore.Mvc;
using PortalGalaxy.Services.Interfaces;
using PortalGalaxy.Shared.Request;

namespace PortalGalaxy.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlumnosController : ControllerBase
{
    private readonly IAlumnoService _service;

    public AlumnosController(IAlumnoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string? nombre, string? nroDocumento)
    {
        var response = await _service.ListAsync(nombre, nroDocumento);

        return Ok(response);
    }
    
    [HttpGet("Simple")]
    public async Task<IActionResult> GetSimple(string? nombre, string? nroDocumento)
    {
        var response = await _service.ListSimpleAsync(nombre, nroDocumento);

        return Ok(response);
    }

    [HttpGet("Eliminados")]
    public async Task<IActionResult> Get()
    {
        var response = await _service.ListarEliminadosAsync();

        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _service.FindByIdAsync(id);

        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AlumnoDtoRequest request)
    {
        var response = await _service.AddAsync(request);

        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, AlumnoDtoRequest request)
    {
        var response = await _service.UpdateAsync(id, request);

        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _service.DeleteAsync(id);

        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id)
    {
        return Ok(await _service.ReactivarAsync(id));
    }
}