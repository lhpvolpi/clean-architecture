using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CleanArchitecture.Core.Common.Extensions
{
    public static class StringExtensions
    {
        public static string ComputeSHA256Hash(this string input)
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

        public static List<KeyValuePair<string, string>> ToListKeyValuePair(string key, string value)
            => new() { new KeyValuePair<string, string>(key, value) };
    }
}

