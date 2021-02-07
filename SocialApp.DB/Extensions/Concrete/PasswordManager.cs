using SocialApp.DB.Extensions.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Extensions.Concrete
{
    public class PasswordManager : IPasswordManager
    {
        public Tuple<byte[], byte[]> CreatePasswordHash(string password)
        {
            byte[] salt, hash;

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

            return new Tuple<byte[], byte[]>(salt, hash);
        }

        public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }
    }
}
