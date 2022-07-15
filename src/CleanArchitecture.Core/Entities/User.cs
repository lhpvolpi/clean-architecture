using System;
using System.Security.Cryptography;
using System.Text;
using CleanArchitecture.Core.Common.Entities;

namespace CleanArchitecture.Core.Entities
{
    public class User : Entity
    {
        public User(string email,
            string username,
            string password)
        {
            this.Email = email;
            this.Username = username;
            this.Password = ComputeSHA256Hash(password);
            this.Code = GenerateCode();
            this.ConfirmedCode = false;
            this.RefreshToken = null;
        }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Code { get; set; }

        public bool ConfirmedCode { get; set; }

        public string? RefreshToken { get; set; }

        public void Update(string email, string username)
        {
            this.Email = email;
            this.Username = username;
            this.UpdatedAt = DateTime.UtcNow;
        }

        public void ChangePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password), "is required");

            if (this.Password == ComputeSHA256Hash(password))
                throw new ArgumentException("new password can't equals old password", nameof(password));

            this.Password = ComputeSHA256Hash(password);
            this.UpdatedAt = DateTime.UtcNow;
        }

        private static string ComputeSHA256Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException(nameof(input), "is required");

            using var sha256 = SHA256.Create();

            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = sha256.ComputeHash(inputBytes);
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
                stringBuilder.Append(hashBytes[i].ToString(@"X2"));

            return stringBuilder.ToString();
        }

        private static string GenerateCode() => Guid.NewGuid().ToString().Replace("-", string.Empty)[..5].ToUpper();

        public override void Activate()
        {
            this.Active = true;
            this.UpdatedAt = DateTime.UtcNow;
        }

        public override void Inactivate()
        {
            this.Active = false;
            this.UpdatedAt = DateTime.UtcNow;
        }
    }
}

