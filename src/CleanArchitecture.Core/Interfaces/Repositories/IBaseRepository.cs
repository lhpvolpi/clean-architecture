using System;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task<T> GetByIdAsync(Guid id);
    }
}

