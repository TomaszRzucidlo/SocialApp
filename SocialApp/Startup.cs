using System;
using System.Collections.Generic;
using System.Linq;
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
using SocialApp.DB.Modules;
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
            services.AddMediatR(typeof(Startup));
            services.AddTransient<DBInitializer>();
            services.AddScoped<MappersModule>();
            services.AddScoped<RepositoriesModule>();
            services.AddScoped<ExtensionsModule>();
            //var builder = new ContainerBuilder();
            //builder.Populate(services);
            //builder.RegisterModule<RepositoriesModule>();
            //builder.RegisterModule<MappersModule>();
            //builder.RegisterModule<ServicesModule>();

            //Container = builder.Build();
            //return new AutofacServiceProvider(Container);
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
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SocialApp");
            //});
            //app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
