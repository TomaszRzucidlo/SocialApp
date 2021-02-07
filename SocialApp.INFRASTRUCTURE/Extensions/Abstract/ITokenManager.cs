using SocialApp.INFRASTRUCTURE.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.INFRASTRUCTURE.Extensions.Abstract
{
    public interface ITokenManager
    {
        TokenDTO GenerateToken(Guid userId, string email);
    }
}
