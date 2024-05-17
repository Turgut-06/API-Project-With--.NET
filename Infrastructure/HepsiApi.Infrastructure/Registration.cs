using HepsiApi.Application.Interfaces.RedisCache;
using HepsiApi.Application.Interfaces.Tokens;
using HepsiApi.Infrastructure.RedisCache;
using HepsiApi.Infrastructure.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Infrastructure
{
    public static class Registration
    {
        //bu registrationları program.cs kısmında da tanıtıyorum
        public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration) //this sayesinde kendi metodunu kendi alıyor
        {
            services.Configure<TokenSettings>(configuration.GetSection("JWT"));
            services.AddTransient<ITokenService,TokenService>();

            services.Configure<RedisCacheSettings>(configuration.GetSection("RedisCacheSettings")); //appsettings development daki alan
            services.AddTransient<IRedisCacheService, RedisCacheService>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; //swagger da üstte oluşacak kilit
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,opt=>
            {
                
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                    ValidateLifetime = false,
                    ValidIssuer= configuration["JWT:Issuer"],
                    ValidAudience= configuration["JWT:Secret"],
                    ClockSkew= TimeSpan.Zero

                };
            });

            //bunlarla dependency injection işlemlerini yapmış oluyorum
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = configuration["RedisCacheSettings : ConnectionString"];
                opt.InstanceName = configuration["RedisCacheSettings : InstanceName"];
            });

        }
    }
}
