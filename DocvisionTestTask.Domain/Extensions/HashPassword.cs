using System.Security.Cryptography;
using System.Text;

namespace DocvisionTestTask.Domain.Extensions
{
    //Хешируем пароль по стандарту SHA256
    public static class HashPassword
    {
        public static string Hash(this string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashBytes).ToLower();
                return hash;
            }
        }
    }
}

