using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Extensions.Abstract
{
    public interface IPasswordManager
    {
        Tuple<byte[], byte[]> CreatePasswordHash(string password);
        bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
