using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Core.Entities
{
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
            var settings = configuration.GetSection("JwtSettings");

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
}

