using Domain.Services;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Services
{
    internal class PasswordHashingService : IPasswordHashingService
    {
        public string HashPassword(string password)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            return Convert.ToBase64String(hashedBytes);
        }

        public bool VerifyPassword(string hashedPassword, string password)
        {
            string hashOfInput = HashPassword(password);

            return string.Equals(hashedPassword, hashOfInput);
        }
    }
}