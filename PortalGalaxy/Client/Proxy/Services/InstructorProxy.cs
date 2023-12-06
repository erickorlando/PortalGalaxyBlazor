using PortalGalaxy.Client.Proxy.Interfaces;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Proxy.Services;

public class InstructorProxy : CrudRestHelperBase<InstructorDtoRequest, InstructorDtoResponse>, IInstructorProxy
{
    public InstructorProxy(HttpClient httpClient) 
        : base("api/Instructores", httpClient)
    {
    }
}