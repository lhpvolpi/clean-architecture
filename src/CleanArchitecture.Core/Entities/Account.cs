using System;
using System.Security.Cryptography;
using System.Text;
using CleanArchitecture.Core.Common.Entities;
using CleanArchitecture.Core.Enums;

namespace CleanArchitecture.Core.Entities
{
    public class Account : Entity
    {
        public Account(string email,
            string username,
            string password)
        {
            this.Email = email;
            this.Username = username;
            this.Password = ComputeSHA256Hash(password);
        }

        public string Password { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string? FullName { get; set; }

        public string? PhoneNumber { get; set; }

        public EGender? Gender { get; set; }

        public DateTime? Birthday { get; set; }

        public void Update(string username,
            string? fullName = null,
            string? phoneNumber = null,
            EGender? gender = null,
            DateTime? birthday = null)
        {
            this.Username = username;
            this.FullName = fullName;
            this.PhoneNumber = phoneNumber;
            this.Gender = gender;
            this.Birthday = birthday;
            this.UpdatedAt = DateTime.UtcNow;
        }

        public void UpdatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password), "is required");

            if (this.Password == ComputeSHA256Hash(password))
                throw new ArgumentException("new password can't equals old password", nameof(password));

            this.Password = ComputeSHA256Hash(password);
            this.UpdatedAt = DateTime.UtcNow;
        }

        public static string ComputeSHA256Hash(string input)
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

