using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);

        Task UpdateAsync(User user);

        Task<User> GetByUsernameAsync(string username);
    }
}

