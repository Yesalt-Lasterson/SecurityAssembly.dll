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
        private readonly byte[] _ID;

        public Password(string password, ID iD)
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
            int[] id = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            if (iD != null)
            {            
                id = iD.RequestID();
            }
            else
            {
                ID eventRaise = new(true);
                id = eventRaise.RequestID();
            }
            StringBuilder sb = new();
            for (int i = 0; i < id.Length; i++)
            {
                sb.Append(id[i]);
            }
            byte[] HashedID = Encoding.UTF8.GetBytes(sb.ToString());
            _ID = SHA512.HashData(HashedID);
        }

        public bool Verify(string password, ID iD)
        {
            // Hash the provided password using SHA512 and the same salt
            byte[] hashedPassword;
            byte[] HashedID;
            using (var sha512 = SHA512.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] saltedPassword = new byte[passwordBytes.Length + _salt.Length];
                Array.Copy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
                Array.Copy(_salt, 0, saltedPassword, passwordBytes.Length, _salt.Length);
                hashedPassword = SHA512.HashData(saltedPassword);
                int[] id = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                if (iD != null)
                {
                    id = iD.RequestID();
                }
                else
                {
                    ID eventRaise = new(true);
                    id = eventRaise.RequestID();
                }
                StringBuilder sb = new();
                for (int i = 0; i < id.Length; i++)
                {
                    sb.Append(id[i]);
                }
                HashedID = Encoding.UTF8.GetBytes(sb.ToString());
                HashedID = SHA512.HashData(HashedID);
            }

            // Compare the hashed passwords
            return Convert.ToBase64String(_hashedPassword) == Convert.ToBase64String(hashedPassword) && _ID == HashedID;
        }
    }
}
