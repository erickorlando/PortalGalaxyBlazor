using AutoMapper;
using Microsoft.Extensions.Logging;
using PortalGalaxy.Entities;
using PortalGalaxy.Repositories.Interfaces;
using PortalGalaxy.Services.Interfaces;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Implementaciones;

public class InstructorService : IInstructorService
{
    private readonly IInstructorRepository _repository;
    private readonly ILogger<InstructorService> _logger;
    private readonly IMapper _mapper;

    public InstructorService(IInstructorRepository repository, ILogger<InstructorService> logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<BaseResponseGeneric<ICollection<InstructorDtoResponse>>> ListAsync(string? filtro)
    {
        var response = new BaseResponseGeneric<ICollection<InstructorDtoResponse>>();
        try
        {
            var collection = await _repository.ListarAsync(filtro);

            response.Data = _mapper.Map<ICollection<InstructorDtoResponse>>(collection);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al listar los instructores";
            _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }
        return response;
    }

    public async Task<BaseResponse> AddAsync(InstructorDtoRequest request)
    {
        var response = new BaseResponse();
        try
        {
            await _repository.AddAsync(_mapper.Map<Instructor>(request));
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al agregar un instructor";
            _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }
        return response;
    }
}