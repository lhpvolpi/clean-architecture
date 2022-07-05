using CleanArchitecture.Core.Entities;
using CleanArchitecture.Infrastructure.Helpers;
using Xunit;

namespace CleanArchitecture.Tests.InfrastructureTests.HelpersTests
{
    public class JwtExtensionsTests : InfrastructureBaseTests
    {
        public JwtExtensionsTests() { }

        [Fact(DisplayName = "should get claim by type")]
        public void Should_Get_Claim_By_Type()
        {
            // arrange
            var user = new User("email@email.com", "admin@123");
            var token = this.JwtService.GenerateToken(user);

            // act
            var userId = token.GetClaimByType(JwtExtensions.NameId);
            var email = token.GetClaimByType(JwtExtensions.Email);

            // assert
            Assert.True(!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(email));
        }
    }
}

