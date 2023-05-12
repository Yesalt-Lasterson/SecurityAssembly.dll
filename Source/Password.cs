using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Permissions;

// Copyright (c) 2023 Yesalt Lasterson
// Read LICENCE.txt

namespace Permissions
{
    internal class Password
    {
        private readonly byte[] _salt;
        private readonly byte[] _hashedPassword;

        public Password(string password)
        {
            // Generate a random salt
            _salt = new byte[16];
            RandomNumberGenerator.Fill(_salt);

            // Hash the password using SHA512
            using var sha512 = SHA512.Create();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPassword = new byte[passwordBytes.Length + _salt.Length];
            Array.Copy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
            Array.Copy(_salt, 0, saltedPassword, passwordBytes.Length, _salt.Length);
            _hashedPassword = SHA512.HashData(saltedPassword);
        }

        public bool Verify(string password)
        {
            // Hash the provided password using SHA512 and the same salt
            byte[] hashedPassword;
            using (var sha512 = SHA512.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] saltedPassword = new byte[passwordBytes.Length + _salt.Length];
                Array.Copy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
                Array.Copy(_salt, 0, saltedPassword, passwordBytes.Length, _salt.Length);
                hashedPassword = SHA512.HashData(saltedPassword);
            }

            // Compare the hashed passwords
            return Convert.ToBase64String(_hashedPassword) == Convert.ToBase64String(hashedPassword);
        }
    }
}
