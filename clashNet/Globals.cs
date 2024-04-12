using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace clashNet
{
    public static class Globals
    {
        public static Dictionary<string, string> users = new Dictionary<string, string>();
        public static byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
        public static string HashPassword(string password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
        }
    }
    public class UserData
    {
        public string user { get; set; }

        public string password { get; set; }
    }
}
