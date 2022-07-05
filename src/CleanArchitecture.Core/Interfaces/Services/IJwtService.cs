using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Interfaces.Services
{
    public interface IJwtService
    {
        public string GenerateToken(User user);

        public Task<bool> ValidateTokenAsync(string token);
    }
}

