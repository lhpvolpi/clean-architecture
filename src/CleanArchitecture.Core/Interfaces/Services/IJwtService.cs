using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.ValueObjects;

namespace CleanArchitecture.Core.Interfaces.Services
{
    public interface IJwtService
    {
        public TokenVO GenerateToken(User user);

        public Task<bool> ValidateTokenAsync(string token);
    }
}

