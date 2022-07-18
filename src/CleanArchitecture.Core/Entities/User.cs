using System;
using CleanArchitecture.Core.Common.Entities;
using CleanArchitecture.Core.Common.Extensions;

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
            this.Password = password.ComputeSHA256Hash();
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

            if (this.Password == password.ComputeSHA256Hash())
                throw new ArgumentException("new password can't equals old password", nameof(password));

            this.Password = password.ComputeSHA256Hash();
            this.UpdatedAt = DateTime.UtcNow;
        }

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

        private static string GenerateCode() => Guid.NewGuid().ToString().Replace("-", string.Empty)[..5].ToUpper();
    }
}

