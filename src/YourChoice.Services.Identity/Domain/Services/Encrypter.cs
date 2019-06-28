using System;
using System.Security.Cryptography;

namespace YourChoice.Services.Identity.Domain.Services
{
    public class Encrypter : IEncrypter
    {
        private static readonly int _saltSize = 40;
        private static readonly int _deriveBytesIterationsCount = 10000;
        
        public string GetSalt(string value)
        {
            var saltBytes = new byte[_saltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        public string GetHash(string value, string salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), _deriveBytesIterationsCount);

            return Convert.ToBase64String(pbkdf2.GetBytes(_saltSize));
        }

        private static byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }
    }
}