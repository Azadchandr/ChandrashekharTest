using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace ChandrashekharTest.Security
{
   
        public static class PasswordHelper
        {
            private const int SaltSize = 16;

            private const int KeySize = 32;

            private const int Iterations = 100000;

            public static string HashPassword(string password)
            {
                byte[] salt = new byte[SaltSize];

                using (var rng =
                       RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }

                byte[] hash;

                using (var pbkdf2 =
                       new Rfc2898DeriveBytes(
                           password,
                           salt,
                           Iterations,
                           HashAlgorithmName.SHA256))
                {
                    hash = pbkdf2.GetBytes(KeySize);
                }

                return Convert.ToBase64String(salt)
                       + ":"
                       + Convert.ToBase64String(hash);
            }

            public static bool VerifyPassword(
                string password,
                string storedHash)
            {
                if (string.IsNullOrWhiteSpace(storedHash))
                    return false;

                string[] parts =
                    storedHash.Split(':');

                if (parts.Length != 2)
                    return false;

                byte[] salt =
                    Convert.FromBase64String(parts[0]);

                byte[] expectedHash =
                    Convert.FromBase64String(parts[1]);

                byte[] actualHash;

                using (var pbkdf2 =
                       new Rfc2898DeriveBytes(
                           password,
                           salt,
                           Iterations,
                           HashAlgorithmName.SHA256))
                {
                    actualHash =
                        pbkdf2.GetBytes(KeySize);
                }

                return FixedTimeEquals(
                    actualHash,
                    expectedHash);
            }

            private static bool FixedTimeEquals(
                byte[] a,
                byte[] b)
            {
                if (a == null || b == null)
                    return false;

                if (a.Length != b.Length)
                    return false;

                int result = 0;

                for (int i = 0; i < a.Length; i++)
                {
                    result |= a[i] ^ b[i];
                }

                return result == 0;
            }
        }
    }



