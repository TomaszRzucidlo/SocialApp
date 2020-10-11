using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Extensions.Abstract
{
    public interface IPasswordManager
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
