using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using NoteBookAPI.Contracts;
using NoteBookAPI.Controllers;
using NoteBookAPI.DbContexts;
using NoteBookAPI.Profiles;
using NoteBookAPI.Repositories;
using NoteBookAPI.Services;
using System;
using System.Text;

namespace NoteBookAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = Configuration["Jwt:Issuer"],
                       ValidAudience = Configuration["Jwt:Issuer"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                   };
               });
       
            services.AddControllers(setupAction=> {
                setupAction.ReturnHttpNotAcceptable = true;
            }).AddNewtonsoftJson(setupAction =>
            {
                setupAction.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }).AddXmlDataContractSerializerFormatters();

            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "NoteBookAPI",
                    Version = "v1"
                });
            });
     
            services.AddScoped<IUserDetailRepositories, UserDetailsRepositories>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IFileRepositories, FileRepositories>();
            services.AddScoped<IFileServices, FileServices>();
            services.AddScoped<ILoginRepositories, LoginRepositories>();
            services.AddScoped<ILoginServices, LoginServices>();
            services.AddScoped<IMetaDataRepositories, MetaDataRepositories>();
            services.AddScoped<IMetaDataServices, MetaDataServices>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDistributedMemoryCache();

            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<LoginController>>();
            var logger1 = serviceProvider.GetService<ILogger<MetaDataController>>();
            var logger2 = serviceProvider.GetService<ILogger<UserController>>();
            var logger3 = serviceProvider.GetService<ILogger<FileController>>();
            services.AddSingleton(typeof(ILogger), logger);
            services.AddSingleton(typeof(ILogger), logger1);
            services.AddSingleton(typeof(ILogger), logger2);
            services.AddSingleton(typeof(ILogger), logger3);

            services.AddDbContext<UserDetailsContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async c =>
                    {
                        c.Response.StatusCode = 500;
                        await c.Response.WriteAsync("Something went horribly wrong");
                    });
                });
            }
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NoteBookAPI");
            });
            app.UseRouting();

            app.UseAuthorization();
          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
