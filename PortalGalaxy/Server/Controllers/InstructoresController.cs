using Microsoft.AspNetCore.Mvc;
using PortalGalaxy.Services.Interfaces;
using PortalGalaxy.Shared.Request;

namespace PortalGalaxy.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstructoresController : ControllerBase
{
    private readonly IInstructorService _service;

    public InstructoresController(IInstructorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string? filtro)
    {
        var response = await _service.ListAsync(filtro);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post(InstructorDtoRequest request)
    {
        var response = await _service.AddAsync(request);

        return response.Success ? Ok(response) : BadRequest(response);
    }
}