using System;
using CleanArchitecture.Core.ValueObjects;
using Xunit;

namespace CleanArchitecture.Tests.CoreTests.ValueObjectsTests
{
    public class TokenTests
    {
        private readonly TokenVO _token;

        private readonly string _accessToken;

        private readonly DateTime _issuedAt;

        private readonly DateTime _expires;


        public TokenTests()
        {
            this._accessToken = Guid.NewGuid().ToString().Replace("-", string.Empty);
            this._issuedAt = DateTime.UtcNow;
            this._expires = this._issuedAt.AddDays(7);

            this._token = new TokenVO(this._accessToken, this._issuedAt, this._expires);
        }

        [Fact(DisplayName = "should create token equals other token")]
        public void Should_Create_Token_Equals_Other_Token()
        {
            // arrgange
            var token = this._token;

            // act
            var result = this._token.Equals(token);

            // assert
            Assert.True(result);
        }

        [Fact(DisplayName = "not should create token equals other token")]
        public void Not_Should_Create_Token_Equals_Other_Token()
        {
            // arrgange
            var accessToken = Guid.NewGuid().ToString().Replace("-", string.Empty);
            var issuedAt = DateTime.UtcNow;
            var expires = issuedAt.AddDays(7);
            var token = new TokenVO(accessToken, issuedAt, expires);

            // act
            var result = this._token.Equals(token);

            // assert
            Assert.False(result);
        }
    }
}