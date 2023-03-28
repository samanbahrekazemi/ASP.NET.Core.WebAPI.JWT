using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
    public class DataSeeder
    {

        private readonly ILogger<DataSeeder> _logger;
        public DataSeeder(ILogger<DataSeeder> logger)
        {
            _logger = logger;
        }
        public async Task SeedUserRolesAsync(RoleManager<Role> roleManager, UserManager<User> userManager)
        {

            try
            {
                var adminRole = new Role
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                };
                var roleResult = await roleManager.CreateAsync(adminRole);
                if (!roleResult.Succeeded)
                    throw new Exception(roleResult.Errors?.FirstOrDefault()?.Description);

                var adminUser = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "AdminUser",
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "Admin@example.com",
                    EmailConfirmed = true,
                    UserRoles = new List<UserRole>() { new UserRole { RoleId = adminRole.Id } }
                };

                if (await userManager.FindByEmailAsync(adminUser.Email) == null)
                {
                    var userResult = await userManager.CreateAsync(adminUser, "Admin@123");
                    if (!userResult.Succeeded)
                        throw new Exception(userResult.Errors?.FirstOrDefault()?.Description);
                }

                _logger.LogInformation("Seed users and roles succeeded.");
            }
            catch (Exception ex)
            {
                //ERROR
                _logger.LogError(ex, "An error occurred while seeding user roles.");
            }
        }

    }
}
