using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace Neoris.Ionleap.CrossCutting.Utils.Cryptography
{
    public class HashPassword
    {

        /// <summary>
        /// Hash algorithm enum
        /// </summary>
        public enum HashType : short
        {
            [Description("SHA1CryptoServiceProvider")]
            Sha1 = 0,
            [DescriptionAttribute("SHA256Managed")]
            Sha256 = 1,
            [DescriptionAttribute("SHA384Managed")]
            Sha384 = 2,
            [DescriptionAttribute("SHA512Managed")]
            Sha512 = 3,
            [DescriptionAttribute("MD5CryptoServiceProvider")]
            Md5 = 4
        }


        /// <summary>
        /// Creates a random salt to add to a password.
        /// </summary>
        /// <returns></returns>
        public static string CreateSalt()
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] number = new byte[32];
            rng.GetBytes(number);
            return Convert.ToBase64String(number);
        }

        /// <summary>
        /// Creates the password hash using a given HashType algorithm.
        /// </summary>
        /// <param name="salt">The salt.</param>
        /// <param name="password">The password.</param>
        /// <param name="hashType">Type of the hash.</param>
        /// <returns></returns>
        public static string CreatePasswordHash(string salt, string password, HashType hashType)
        {
            string hashString = string.Empty;
            if (!string.IsNullOrEmpty(password))
            {
                HashAlgorithm hashAlgorithm = HashAlgorithm.Create(hashType.ToString());
                byte[] passwordData = Encoding.Default.GetBytes(salt + password);
                byte[] hash = hashAlgorithm.ComputeHash(passwordData);
                hashString = Convert.ToBase64String(hash);
            }
            return hashString;
        }

        /// <summary>
        /// Creates the password hash using SHA256 managed hash algorithm.
        /// </summary>
        /// <param name="salt">The password salt.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static string CreatePasswordHash(string salt, string password)
        {
            return CreatePasswordHash(salt, password, HashType.Sha256);
        }

        /// <summary>
        /// Encrypts the password in SHA256.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="salt">The salt.</param>
        /// <returns></returns>
        public static string EncryptPassword(string password, out string salt)
        {
            salt = CreateSalt();
            return CreatePasswordHash(salt, password);
        }

        /// <summary>
        /// Encrypts the password by HashType.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="hashType">Type of the hash.</param>
        /// <returns></returns>
        public static string EncryptPassword(string password, out string salt, HashType hashType)
        {
            salt = CreateSalt();
            return CreatePasswordHash(salt, password, hashType);
        }

    }
}
