using AutoMapper;
using Microsoft.Extensions.Logging;
using PortalGalaxy.Entities;
using PortalGalaxy.Repositories.Interfaces;
using PortalGalaxy.Services.Interfaces;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Implementaciones;

public class AlumnoService : IAlumnoService
{
    private readonly IAlumnoRepository _repository;
    private readonly ILogger<AlumnoService> _logger;
    private readonly IMapper _mapper;

    public AlumnoService(IAlumnoRepository repository, ILogger<AlumnoService> logger, IMapper mapper)
    {
        _mapper = mapper;
        _logger = logger;
        _repository = repository;
    }

    public async Task<BaseResponseGeneric<ICollection<AlumnoDtoResponse>>> ListAsync(string? filtro, string? nroDocumento)
    {
        var response = new BaseResponseGeneric<ICollection<AlumnoDtoResponse>>();

        try
        {
            response.Data = await _repository
                .ListAsync(predicado: x => x.NombreCompleto.Contains(filtro ?? string.Empty)
                && x.NroDocumento.StartsWith(nroDocumento ?? string.Empty),
                selector: x => _mapper.Map<AlumnoDtoResponse>(x));

            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al cargar los alumnos";
            _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;
    }

    public async Task<BaseResponseGeneric<AlumnoDtoResponse>> FindByIdAsync(int id)
    {

        var response = new BaseResponseGeneric<AlumnoDtoResponse>();

        try
        {
            var data = await _repository.FindAsync(id);

            response.Data = _mapper.Map<AlumnoDtoResponse>(data);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al buscar el Alumno";
            _logger.LogError(ex, "{ErroMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;

    }


    public async Task<BaseResponse> AddAsync(AlumnoDtoRequest request)
    {

        var response = new BaseResponse();

        try
        {
            await _repository.AddAsync(_mapper.Map<Alumno>(request));
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al agregar";
            _logger.LogError(ex, "{ErroMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;

    }

    public async Task<BaseResponse> UpdateAsync(int id, AlumnoDtoRequest request)
    {

        var response = new BaseResponse();

        try
        {
            var registro = await _repository.FindAsync(id);

            if (registro is not null)
            {
                _mapper.Map(request, registro);

                await _repository.UpdateAsync();
            }

            response.Success = registro != null;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al actualizar";
            _logger.LogError(ex, "{ErroMessage} {Message}", response.ErrorMessage, ex.Message);
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
            response.ErrorMessage = "Error al eliminar";
            _logger.LogError(ex, "{ErroMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;

    }

    public async Task<BaseResponseGeneric<ICollection<AlumnoDtoResponse>>> ListarEliminadosAsync()
    {

        var response = new BaseResponseGeneric<ICollection<AlumnoDtoResponse>>();

        try
        {
            var data = await _repository.ListarEliminados();

            response.Data = _mapper.Map<ICollection<AlumnoDtoResponse>>(data);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al listar eliminados";
            _logger.LogError(ex, "{ErroMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;

    }

    public async Task<BaseResponse> ReactivarAsync(int id)
    {

        var response = new BaseResponse();

        try
        {
            await _repository.Reactivar(id);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al reactivar";
            _logger.LogError(ex, "{ErroMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;

    }
}