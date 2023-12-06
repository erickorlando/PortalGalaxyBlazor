using AutoMapper;
using Microsoft.Extensions.Logging;
using PortalGalaxy.Entities;
using PortalGalaxy.Repositories.Interfaces;
using PortalGalaxy.Services.Interfaces;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Implementaciones;

public class TallerService : ITallerService
{
    private readonly ITallerRepository _repository;
    private readonly ILogger<TallerService> _logger;
    private readonly IMapper _mapper;
    private readonly IFileUploader _fileUploader;

    public TallerService(ITallerRepository repository, ILogger<TallerService> logger, IMapper mapper, IFileUploader fileUploader)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _fileUploader = fileUploader;
    }

    public async Task<BaseResponse> AddAsync(TallerDtoRequest request)
    {
        var response = new BaseResponse();
        try
        {
            var entity = _mapper.Map<Taller>(request);

            entity.PortadaUrl = await _fileUploader.UploadFileAsync(request.Base64Portada, request.ArchivoPortada);
            entity.TemarioUrl = await _fileUploader.UploadFileAsync(request.Base64Temario, request.ArchivoTemario);

            await _repository.AddAsync(entity);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al agregar un Taller";
            _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }
        return response;
    }

    public async Task<PaginationResponse<TallerDtoResponse>> ListAsync(BusquedaTallerRequest request)
    {
        var response = new PaginationResponse<TallerDtoResponse>();
        try
        {
            var tupla = await _repository.ListarTalleresAsync(request.Nombre, request.CategoriaId, request.Situacion, request.Pagina, request.Filas);

            response.Data = _mapper.Map<ICollection<TallerDtoResponse>>(tupla.Collection);
            response.TotalPages = tupla.Total / request.Filas;
            if (tupla.Total % request.Filas > 0)
            {
                response.TotalPages++;
            }

            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "Error al listar los Talleres";
            _logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
        }
        return response;
    }
}