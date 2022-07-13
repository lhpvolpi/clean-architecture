using System;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Common;
using MongoDB.Driver;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMongoCollection<Account> _collection;

        public AccountRepository(IMongoDbSettings mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.DatabaseName);

            this._collection = database.GetCollection<Account>(mongoDbSettings.AccountCollection);
        }

        public async Task CreateAsync(Account account) => await this._collection.InsertOneAsync(account);

        public async Task<Account> GetByIdAsync(Guid id) => await this._collection.Find(i => i.Id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(Account account) => await this._collection.ReplaceOneAsync(i => i.Id == account.Id, account);
    }
}

