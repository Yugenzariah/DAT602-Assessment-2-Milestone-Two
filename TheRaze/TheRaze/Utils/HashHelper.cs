using System.Security.Cryptography;
using System.Text;

namespace TheRaze.Utils
{
    public static class HashHelper
    {
        public static string FakeHash(string plain)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(plain ?? string.Empty));
            // Your DB column is CHAR(60) in the prototype — pad to 60 chars.
            return Convert.ToHexString(bytes).PadRight(60, 'X');
        }
    }
}
