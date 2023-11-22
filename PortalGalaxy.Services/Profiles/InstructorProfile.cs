using AutoMapper;
using PortalGalaxy.Entities;
using PortalGalaxy.Entities.Infos;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Services.Profiles;

public class InstructorProfile : Profile
{
    public InstructorProfile()
    {
        CreateMap<Instructor, InstructorDtoResponse>();

        CreateMap<InstructorDtoRequest, Instructor>();

        CreateMap<InstructorInfo, InstructorDtoResponse>();
    }
}