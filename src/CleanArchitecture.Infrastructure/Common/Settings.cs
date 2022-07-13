using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Infrastructure.Common
{
    #region jwt

    public interface IJwtSettings
    {
        string Audience { get; set; }

        int ExpiresInDays { get; set; }

        string Issuer { get; set; }

        string Secret { get; set; }
    }

    public class JwtSettings : IJwtSettings
    {

        public JwtSettings(IConfiguration configuration)
        {
            var settings = configuration.GetSection("Jwt");

            this.Audience = settings.GetValue<string>("Audience");
            this.ExpiresInDays = settings.GetValue<int>("ExpiresInDays");
            this.Issuer = settings.GetValue<string>("Issuer");
            this.Secret = settings.GetValue<string>("Secret");
        }

        public string Audience { get; set; }

        public int ExpiresInDays { get; set; }

        public string Issuer { get; set; }

        public string Secret { get; set; }
    }

    #endregion

    #region mongodb

    public interface IMongoDbSettings
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }

        string AccountCollection { get; set; }
    }

    public class MongoDbSettings : IMongoDbSettings
    {
        public MongoDbSettings(IConfiguration configuration)
        {
            var settings = configuration.GetSection("MongoDb");

            this.ConnectionString = settings.GetValue<string>("ConnectionString");
            this.DatabaseName = settings.GetValue<string>("DatabaseName");
            this.AccountCollection = settings.GetValue<string>("AccountCollection");
        }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string AccountCollection { get; set; }
    }

    #endregion
}

