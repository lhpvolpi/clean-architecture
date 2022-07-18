using System;
using System.Collections.Generic;

namespace CleanArchitecture.Core.ValueObjects
{
    public class TokenVO : ValueObject
    {
        public TokenVO(string accessToken,
            DateTime issuedAt,
            DateTime expires)
        {
            this.AccessToken = accessToken;
            this.RefreshToken = GenerateRefreshToken();
            this.IssuedAt = issuedAt;
            this.Expires = expires;
        }

        public string AccessToken { get; private set; }

        public string RefreshToken { get; private set; }

        public DateTime IssuedAt { get; set; }

        public DateTime Expires { get; set; }

        public bool IsExpired => DateTime.UtcNow >= Expires;

        private static string GenerateRefreshToken()
            => Guid.NewGuid().ToString().Replace("-", string.Empty);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.AccessToken;
            yield return this.RefreshToken;
            yield return this.IssuedAt;
            yield return this.Expires;
            yield return this.IsExpired;
        }
    }
}

