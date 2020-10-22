using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialApp.DB.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Extensions
{
    public static class SettingsExtension
    {
        private const string DatabaseSettingsKey = "DatabaseSettings";
        private const string JwtSettingsKey = "JwtSettings";
        private const string EmailSettingsKey = "EmailSettings";

        public static void AddApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<DatabaseSettings>(configuration.GetSection(DatabaseSettingsKey));
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettingsKey));
            //services.Configure<EmailSettings>(configuration.GetSection(EmailSettingsKey));
        }
    }
}
