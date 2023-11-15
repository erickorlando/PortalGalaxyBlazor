using AutoMapper;
using Microsoft.Extensions.Logging;
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

}