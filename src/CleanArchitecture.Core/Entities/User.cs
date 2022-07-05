using System;
using System.Security.Cryptography;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class User : Entity
    {
        public User(string email,
            string password)
        {
            this.Email = email;
            this.Password = ComputeSHA256Hash(password);
        }

        public string Email { get; set; }

        public string Password { get; set; }

        public void Update(string email)
        {
            this.Email = email;
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
    }
}

