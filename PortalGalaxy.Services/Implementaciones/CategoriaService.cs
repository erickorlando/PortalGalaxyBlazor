using AutoMapper;
using Microsoft.Extensions.Logging;
using PortalGalaxy.Entities;
using PortalGalaxy.Repositories.Interfaces;
using PortalGalaxy.Services.Interfaces;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Implementaciones;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly ILogger<CategoriaService> _logger;
    private readonly IMapper _mapper;

    public CategoriaService(ICategoriaRepository categoriaRepository, ILogger<CategoriaService> logger, IMapper mapper)
    {
        _categoriaRepository = categoriaRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<BaseResponseGeneric<ICollection<CategoriaDtoResponse>>> ListAsync()
    {
        var response = new BaseResponseGeneric<ICollection<CategoriaDtoResponse>>();

        try
        {
            var collection = await _categoriaRepository.ListAsync();

            response.Data = _mapper.Map<ICollection<CategoriaDtoResponse>>(collection);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al listar las categorias";
            _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;
    }

    public async Task<BaseResponseGeneric<CategoriaDtoRequest>> FindByIdAsync(int id)
    {
        var response = new BaseResponseGeneric<CategoriaDtoRequest>();

        try
        {
            var categoria = await _categoriaRepository.FindAsync(id);

            response.Data = _mapper.Map<CategoriaDtoRequest>(categoria);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al obtener la categoria";
            _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;
    }

    public async Task<BaseResponse> AddAsync(CategoriaDtoRequest request)
    {
        var response = new BaseResponse();

        try
        {
            await _categoriaRepository.AddAsync(_mapper.Map<Categoria>(request));

            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al agregar la categoria";
            _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;
    }

    public async Task<BaseResponse> UpdateAsync(int id, CategoriaDtoRequest request)
    {
        var response = new BaseResponse();

        try
        {
            var entity = await _categoriaRepository.FindAsync(id);
            if (entity is null)
            {
                response.ErrorMessage = "No se encontro la categoria";
                return response;
            }

            _mapper.Map(request, entity);

            await _categoriaRepository.UpdateAsync();

            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al actualizar la categoria";
            _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;
    }

    public async Task<BaseResponse> DeleteAsync(int id)
    {
        var response = new BaseResponse();

        try
        {
            await _categoriaRepository.DeleteAsync(id);

            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al eliminar la categoria";
            _logger.LogCritical(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }

        return response;
    }
}