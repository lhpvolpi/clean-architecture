using System;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using Xunit;

namespace CleanArchitecture.Tests.InfrastructureTests.ServicesTests
{
    public class JwtServiceTests : InfrastructureBaseTests
    {
        public JwtServiceTests() { }

        [Fact(DisplayName = "should generate token")]
        public void Should_Generate_Token()
        {
            // arrange
            var user = new User("email@email.com", "admin", "admin@123");

            // act
            var result = this.JwtService.GenerateToken(user);

            // assert
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "should validate token")]
        public async Task Should_Validate_Token()
        {
            // arrange
            var user = new User("email@email.com", "admin", "admin@123");
            var token = this.JwtService.GenerateToken(user);

            // act
            var result = await this.JwtService.ValidateTokenAsync(token.AccessToken);

            // assert
            Assert.True(result);
        }

        [Fact(DisplayName = "not should validate token")]
        public void Not_Should_Validate_Token()
        {
            // arrange, act, assert
            Assert.ThrowsAnyAsync<ArgumentNullException>(async () => await this.JwtService.ValidateTokenAsync(string.Empty));
        }
    }
}

