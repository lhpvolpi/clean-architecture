using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Infrastructure.Common
{
    #region jwt

    public interface IJwtSettings
    {
        string Audience { get; }

        int ExpiresInDays { get; }

        string Issuer { get; }

        string Secret { get; }
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

        public string Audience { get; }

        public int ExpiresInDays { get; }

        public string Issuer { get; }

        public string Secret { get; }
    }

    #endregion

    #region smtp

    public interface ISmtpSettings
    {
        string From { get; }

        string Password { get; }

        string Host { get; }

        int Port { get; }

    }

    public class SmtpSettings : ISmtpSettings
    {
        public SmtpSettings(IConfiguration configuration)
        {
            var settings = configuration.GetSection("Smtp");

            this.From = settings.GetValue<string>("From");
            this.Password = settings.GetValue<string>("Password");
            this.Host = settings.GetValue<string>("Host");
            this.Port = settings.GetValue<int>("Port");
        }

        public string From { get; }

        public string Password { get; }

        public string Host { get; }

        public int Port { get; }
    }

    #endregion

    #region mongodb

    public interface IMongoDbSettings
    {
        string ConnectionString { get; }

        string DatabaseName { get; }

        string UserCollection { get; }
    }

    public class MongoDbSettings : IMongoDbSettings
    {
        public MongoDbSettings(IConfiguration configuration)
        {
            var settings = configuration.GetSection("MongoDb");

            this.ConnectionString = settings.GetValue<string>("ConnectionString");
            this.DatabaseName = settings.GetValue<string>("DatabaseName");
            this.UserCollection = settings.GetValue<string>("UserCollection");
        }

        public string ConnectionString { get; }

        public string DatabaseName { get; }

        public string UserCollection { get; }
    }

    #endregion

    #region redis

    public interface IRedisSettings
    {
        string ConnectionString { get; }

        int ExpiresInMinutes { get; }
    }

    public class RedisSettings : IRedisSettings
    {
        public RedisSettings(IConfiguration configuration)
        {
            var settings = configuration.GetSection("Redis");

            this.ConnectionString = settings.GetValue<string>("ConnectionString");
            this.ExpiresInMinutes = settings.GetValue<int>("ExpiresInMinutes");
        }

        public string ConnectionString { get; }

        public int ExpiresInMinutes { get; }
    }

    #endregion
}

