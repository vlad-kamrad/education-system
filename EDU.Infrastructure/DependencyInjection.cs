using EDU.Application;
using EDU.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, JWTAuthService>();
            services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
            services.Configure<TokenSettings>(configuration.GetSection("TokenSettings"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];
                            var path = context.HttpContext.Request.Path;
                            // Here
                            if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hub"))
                            {
                                context.Request.Headers.Add("Authorization", $"Bearer {accessToken}");
                                context.Token = accessToken;
                            }

                            return Task.CompletedTask;
                        }
                    };

                    var tokenSettings = configuration.GetSection("TokenSettings");
                    var isk = tokenSettings.GetSection("IssuerSigningKey").Value;
                    var vi = tokenSettings.GetSection("Issuer").Value;
                    var va = tokenSettings.GetSection("Audience").Value;

                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(isk)),
                        ValidIssuer = vi,
                        ValidAudience = va,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });


            return services;
        }
    }
}
