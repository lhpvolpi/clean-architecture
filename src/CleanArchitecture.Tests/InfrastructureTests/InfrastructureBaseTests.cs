using System;
using CleanArchitecture.Infrastructure.Common;
using CleanArchitecture.Infrastructure.Services;
using Moq;

namespace CleanArchitecture.Tests.InfrastructureTests
{
    public class InfrastructureBaseTests
    {
        public readonly Mock<IJwtSettings> mockJwtSettings;

        public readonly Mock<ISmtpSettings> mockSmtpSettings;

        public readonly JwtService jwtService;

        public readonly SmtpService smtpService;

        public InfrastructureBaseTests()
        {
            #region jwt

            this.mockJwtSettings = new Mock<IJwtSettings>();

            this.mockJwtSettings.Setup(i => i.Secret).Returns(Guid.NewGuid().ToString());
            this.mockJwtSettings.Setup(i => i.Audience).Returns("clean architecture audience");
            this.mockJwtSettings.Setup(i => i.Issuer).Returns("clean architecture issuer");
            this.mockJwtSettings.Setup(i => i.ExpiresInDays).Returns(7);

            this.jwtService = new JwtService(this.mockJwtSettings.Object);

            #endregion

            #region smtp

            this.mockSmtpSettings = new Mock<ISmtpSettings>();

            this.mockSmtpSettings.Setup(i => i.From).Returns("rosario.abernathy@ethereal.email");
            this.mockSmtpSettings.Setup(i => i.Password).Returns("5dEXPWTjYjvtaqPGHv");
            this.mockSmtpSettings.Setup(i => i.Host).Returns("smtp.ethereal.email");
            this.mockSmtpSettings.Setup(i => i.Port).Returns(587);

            this.smtpService = new SmtpService(this.mockSmtpSettings.Object);

            #endregion
        }
    }
}

