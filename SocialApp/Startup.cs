using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SocialApp.DB.Domain.Concrete;
using SocialApp.DB.Domain.Initializers;
using SocialApp.DB.Extensions;
using SocialApp.DB.Extensions.Abstract;
using SocialApp.DB.Extensions.Concrete;
using SocialApp.DB.Modules;
using SocialApp.DB.Repositories.Abstract;
using SocialApp.DB.Repositories.Concrete;
using SocialApp.INFRASTRUCTURE.Extensions.Abstract;
using SocialApp.INFRASTRUCTURE.Extensions.Concrete;
using SocialApp.INFRASTRUCTURE.Handlers;
using SocialApp.INFRASTRUCTURE.Modules;

namespace SocialApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationSettings(Configuration);
            var val = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SocialAppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddControllers();
            //services.AddSwagger();
            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddTransient<DBInitializer>();
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IPasswordManager), typeof(PasswordManager));
            services.AddScoped(typeof(ITokenManager), typeof(TokenManager));
            services.AddMediatR(typeof(RegisterUserHandler).GetTypeInfo().Assembly);
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DBInitializer contextSeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using(var serviceSkope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceSkope.ServiceProvider.GetRequiredService<SocialAppDbContext>();
                if (context.Database.EnsureCreated())
                {
                    contextSeeder.Seed().Wait();
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
