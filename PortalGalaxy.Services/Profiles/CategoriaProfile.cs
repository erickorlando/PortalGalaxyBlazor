using AutoMapper;
using PortalGalaxy.Entities;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Profiles;

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<Categoria, CategoriaDtoResponse>();
    }
}