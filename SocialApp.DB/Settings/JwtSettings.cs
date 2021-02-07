using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Settings
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public int ExpiresMinutes { get; set; }
        public string Issuer { get; set; }
    }
}
