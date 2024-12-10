using System;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication1.Utils {
    /// <summary>
    /// Provides methods for SHA256 hashing and verification
    /// </summary>
    public static class SHA256Encryption {
        /// <summary>
        /// Computes SHA256 hash of the input string
        /// </summary>
        /// <param name="input">The string to hash</param>
        /// <returns>SHA256 hash as a hexadecimal string</returns>
        public static string Encrypt(string input) {
            // Convert the input string to a byte array and compute the hash
            using (SHA256 sha256Hash = SHA256.Create()) {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Verifies if an input string matches a stored hash
        /// </summary>
        /// <param name="input">The input string to verify</param>
        /// <param name="hash">The stored hash to verify against</param>
        /// <returns>True if the input matches the hash, false otherwise</returns>
        public static bool Compare(string input, string hash) {
            // Hash the input
            string hashOfInput = Encrypt(input);

            // Create a StringComparer for a case-insensitive comparison
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            // Compare the hashes
            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }
}