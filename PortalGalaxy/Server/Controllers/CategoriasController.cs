using Microsoft.AspNetCore.Mvc;
using PortalGalaxy.Services.Interfaces;
using PortalGalaxy.Shared.Request;

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
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _service.FindByIdAsync(id);

        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CategoriaDtoRequest request)
    {
        var response = await _service.AddAsync(request);

        return Ok(response);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, CategoriaDtoRequest request)
    {
        var response = await _service.UpdateAsync(id, request);

        return Ok(response);
    }
    

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _service.DeleteAsync(id);

        return Ok(response);
    }

}