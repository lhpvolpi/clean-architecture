using System;
using CleanArchitecture.Core.ValueObjects;
using Xunit;

namespace CleanArchitecture.Tests.CoreTests.ValueObjectsTests
{
    public class TokenTests
    {
        private readonly TokenVO _token;

        public TokenTests()
        {
            var accessToken = Guid.NewGuid().ToString().Replace("-", string.Empty);
            var issuedAt = DateTime.UtcNow;
            var expires = issuedAt.AddDays(7);

            this._token = new TokenVO(accessToken, issuedAt, expires);
        }

        [Fact(DisplayName = "should create token")]
        public void Should_Create_Token()
        {
            // arrgange

            // act

            // assert
        }
    }
}