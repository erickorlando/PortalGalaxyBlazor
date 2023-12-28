using AutoMapper;
using Microsoft.Extensions.Logging;
using PortalGalaxy.Entities;
using PortalGalaxy.Repositories.Interfaces;
using PortalGalaxy.Services.Interfaces;
using PortalGalaxy.Services.Utils;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Implementaciones;

public class InscripcionService : IInscripcionService
{
    private readonly IInscripcionRepository _repository;
    private readonly IAlumnoRepository _alumnoRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<InscripcionService> _logger;

    public InscripcionService(IInscripcionRepository repository, IAlumnoRepository alumnoRepository, 
        IMapper mapper, ILogger<InscripcionService> logger)
    {
        _repository = repository;
        _alumnoRepository = alumnoRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<PaginationResponse<InscripcionDtoResponse>> ListAsync(BusquedaInscripcionRequest request)
    {
        var response = new PaginationResponse<InscripcionDtoResponse>();

        try
        {
            // Codigo
            var tupla = await _repository.ListAsync(request.Inscrito, request.Taller, request.Situacion,
                request.FechaInicio, request.FechaFin, request.Pagina, request.Filas);

            response.Data = _mapper.Map<ICollection<InscripcionDtoResponse>>(tupla.Colecction);
            response.TotalPages = Helper.GetTotalPages(tupla.Total, request.Filas);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al listar las inscripciones";
            _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;

    }

    public async Task<BaseResponse> AddAsync(string email, InscripcionDtoRequest request)
    {
        var response = new BaseResponse();

        try
        {
            // Codigo
            var entity = _mapper.Map<Inscripcion>(request);
            
            var alumno = await _alumnoRepository.FindByEmailAsync(email);
            if (alumno is null)
            {
                response.ErrorMessage = "El alumno no existe";
                return response;
            }

            entity.AlumnoId = alumno.Id;
            entity.Situacion = SituacionInscripcion.Asistira;

            await _repository.AddAsync(entity);

            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al agregar la inscripcion";
            _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;

    }

    public async Task<BaseResponseGeneric<InscripcionDtoRequest>> FindByIdAsync(int id)
    {
        var response = new BaseResponseGeneric<InscripcionDtoRequest>();

        try
        {
            // Codigo
            var entity = await _repository.FindByIdAsync(id);
            if (entity is null)
            {
                response.ErrorMessage = "La inscripcion no existe";
                return response;
            }

            response.Data = _mapper.Map<InscripcionDtoRequest>(entity);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al buscar la inscripcion";
            _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;
    }

    public async Task<BaseResponse> UpdateAsync(string email, int id, InscripcionDtoRequest request)
    {
        var response = new BaseResponse();

        try
        {
            // Codigo
            var entity = await _repository.FindByIdAsync(id);
            if (entity is null)
            {
                response.ErrorMessage = "La inscripcion no existe";
                return response;
            }

            var alumno = await _alumnoRepository.FindByEmailAsync(email);
            if (alumno is null)
            {
                response.ErrorMessage = "El alumno no existe";
                return response;
            }

            entity.AlumnoId = alumno.Id;
            entity.Situacion = (SituacionInscripcion)request.Situacion;

            await _repository.UpdateAsync();

            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al actualizar la inscripcion";
            _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;
    }

    public async Task<BaseResponse> DeleteAsync(int id)
    {
        var response = new BaseResponse();

        try
        {
            await _repository.DeleteAsync(id);

            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al eliminar la inscripcion";
            _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;
    }
}