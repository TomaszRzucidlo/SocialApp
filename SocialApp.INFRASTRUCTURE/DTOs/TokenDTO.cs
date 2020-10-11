using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.INFRASTRUCTURE.DTOs
{
    public class TokenDTO
    {
        public string Email { get; set; }
        public string Token { get; set; }

        public TokenDTO(string token, string email)
        {
            Email = email;
            Token = token;
        }
    }
}
