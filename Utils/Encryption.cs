using System.Security.Cryptography;
using System.Text;

namespace Utils {
    public static class Sha256Encryption {
        private const int SaltSize = 16; // 128 bits

        public static string Encrypt(string input) {
            string salt = GenerateSalt();
            string hash = ComputeHash(input, salt);
            return $"{hash}:{salt}";
        }

        public static bool Compare(string input, string hashWithSalt) {
            var parts = hashWithSalt.Split(':');
            if (parts.Length != 2)
                return false;

            string storedHash = parts[0];
            string storedSalt = parts[1];

            string computedHash = ComputeHash(input, storedSalt);
            return computedHash == storedHash;
        }

        private static string GenerateSalt() {
            using (var rng = new RNGCryptoServiceProvider()) {
                byte[] saltBytes = new byte[SaltSize];
                rng.GetBytes(saltBytes);
                return Convert.ToBase64String(saltBytes);
            }
        }

        private static string ComputeHash(string input, string salt) {
            using (var sha256 = SHA256.Create()) {
                string inputWithSalt = input + salt;
                byte[] inputBytes = Encoding.UTF8.GetBytes(inputWithSalt);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
