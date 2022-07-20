using System;
using System.Text.Json;
using System.Threading.Tasks;
using CleanArchitecture.Core.Interfaces.Services;
using CleanArchitecture.Infrastructure.Common;
using StackExchange.Redis;

namespace CleanArchitecture.Infrastructure.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly ConnectionMultiplexer _client;

        private readonly IRedisSettings _redisSettings;

        public RedisCacheService(IRedisSettings redisSettings)
        {
            this._redisSettings = redisSettings;
            this._client = ConnectionMultiplexer.Connect(this._redisSettings.ConnectionString);
        }

        public async Task DeleteAsync(string key)
        {
            await this._client.GetDatabase().KeyDeleteAsync(key);
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await this._client.GetDatabase().StringGetAsync(key);

            if (!value.IsNullOrEmpty)
                return JsonSerializer.Deserialize<T>(value.ToString());

            return default;
        }

        public async Task SetAsync<T>(string key, T value)
        {
            var expiresInTimeSpan = DateTime.UtcNow.AddMinutes(this._redisSettings.ExpiresInMinutes).Subtract(DateTime.UtcNow);
            await this._client.GetDatabase().StringSetAsync(key, JsonSerializer.Serialize(value), expiresInTimeSpan);
        }
    }
}

