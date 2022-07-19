using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Services
{
    public interface ICacheService
    {
        Task<T?> GetAsync<T>(string key);

        Task SetAsync<T>(string key, T value);

        Task DeleteAsync(string key);
    }
}

