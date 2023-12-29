using AutoMapper;
using PortalGalaxy.Entities;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Profiles;

public class AlumnoProfile : Profile
{
    public AlumnoProfile()
    {
        CreateMap<Alumno, AlumnoSimpleDtoResponse>()
            .ForMember(d => d.FechaRegistro, o => o.MapFrom(x => x.FechaCreacion.ToString("dd/MM/yyyy")));
    }
}