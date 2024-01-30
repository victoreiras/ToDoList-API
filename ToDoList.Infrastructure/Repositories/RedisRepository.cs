
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using ToDoList.Domain.interfaces;

namespace ToDoList.Infrastructure.Repositories;

public class RedisRepository : ICacheRepository
{
    private readonly IDistributedCache _cache;
    private readonly DistributedCacheEntryOptions options;

    public RedisRepository(IDistributedCache cache)
    {
        _cache = cache;
        options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
            SlidingExpiration = TimeSpan.FromSeconds(1200)
        };
    }
    public async Task<T> GetAsync<T>(string key)
    {
        var value = await _cache.GetStringAsync(key);

        return JsonSerializer.Deserialize<T>(value);
    }

    public async Task SetAsync<T>(string key, T value)
    {
        var jsonValue = JsonSerializer.Serialize(value);
        await _cache.SetStringAsync(key, jsonValue, options);
    }
}