using AutoMapper;
using PortalGalaxy.Entities;
using PortalGalaxy.Entities.Infos;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Profiles;

public class TallerProfile : Profile
{
    public TallerProfile()
    {
        CreateMap<TallerInfo, TallerDtoResponse>()
            .ForMember(d => d.Fecha, o => o.MapFrom(x => x.Fecha.ToString("dd/MM/yyyy")));

        CreateMap<TallerDtoRequest, Taller>();
    }
}