using System;
using CleanArchitecture.Infrastructure.Common;
using CleanArchitecture.Infrastructure.Services;
using Moq;

namespace CleanArchitecture.Tests.InfrastructureTests
{
    public class InfrastructureBaseTests
    {
        public readonly Mock<IJwtSettings> mockJwtSettings;

        public JwtService JwtService { get; set; }

        public InfrastructureBaseTests()
        {
            this.mockJwtSettings = new Mock<IJwtSettings>();

            this.mockJwtSettings.Setup(i => i.Secret).Returns(Guid.NewGuid().ToString());
            this.mockJwtSettings.Setup(i => i.Audience).Returns("clean architecture audience");
            this.mockJwtSettings.Setup(i => i.Issuer).Returns("clean architecture issuer");
            this.mockJwtSettings.Setup(i => i.ExpiresInDays).Returns(7);

            this.JwtService = new JwtService(this.mockJwtSettings.Object);
        }
    }
}

