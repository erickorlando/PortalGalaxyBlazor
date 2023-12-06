using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Proxy.Interfaces;

public interface ICrudRestHelper<TRequest, TResponse>
where TRequest : class
where TResponse : class
{
    Task<PaginationResponse<TResponse>> ListAsync(string? filter, int page = 1, int pageSize = 5);

    Task<ICollection<TResponse>> ListAsync();

    Task<TRequest> FindByIdAsync(int id);

    Task CreateAsync(TRequest request);

    Task UpdateAsync(int id, TRequest request);

    Task DeleteAsync(int id);
}