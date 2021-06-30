using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.INFRASTRUCTURE.DTOs
{
    public class TokenDTO
    {
        public string Token { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }

        public TokenDTO(string token, string firstName, string lastName, string imageUrl)
        {
            Token = token;
            FullName = $"{firstName} {lastName}";
            ImageUrl = imageUrl;
        }
    }
}
