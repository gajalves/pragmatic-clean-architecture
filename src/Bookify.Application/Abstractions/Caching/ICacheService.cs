namespace Bookify.Application.Abstractions.Caching;

public interface ICacheService
{
    Task<T?> GetAsync<T>(string key, CancellationToken cancellation = default);

    Task SetAsync<T>(
        string key, 
        T value, 
        TimeSpan? expiration = null,
        CancellationToken cancellation = default);

    Task RemoveAsync(string key, CancellationToken cancellationToken = default);
}
