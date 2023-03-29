using Domain.Entities;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            bool useInMemoryDatabase = config.GetValue<bool>("UseInMemoryDatabase");

            if (useInMemoryDatabase)
            {
                // Add the in-memory database context
                services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("InMemoryDatabase"));
            }
            else
            {
                // Add the SqlServer database context
                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            }

            // For Identity
            services.AddDefaultIdentity<User>()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


            // Add JWT authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });


            // Add authorization policies
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("admin", policy =>
            //        policy.RequireRole("admin"));
            //    options.AddPolicy("operator", policy =>
            //        policy.RequireRole("operator"));
            //});


            // Register UserManager<User> service
            services.AddScoped<UserManager<User>>();
            services.AddScoped<RoleManager<Role>>();


            return services;
        }
    }
}
