using System;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Common;
using MongoDB.Driver;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _collection;

        public UserRepository(IMongoDbSettings mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.DatabaseName);

            this._collection = database.GetCollection<User>(mongoDbSettings.UserCollection);
        }

        public async Task CreateAsync(User user)
            => await this._collection.InsertOneAsync(user);

        public async Task<User> GetByIdAsync(Guid id)
            => await this._collection.Find(i => i.Id == id).FirstOrDefaultAsync();

        public async Task<User> GetByUsernameAsync(string username)
            => await this._collection.Find(i => i.Username == username || i.Email == username).FirstOrDefaultAsync();

        public async Task UpdateAsync(User user)
            => await this._collection.ReplaceOneAsync(i => i.Id == user.Id, user);
    }
}

