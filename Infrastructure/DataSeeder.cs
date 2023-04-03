using Application.Interfaces;
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


        public async Task SeedProductsAsync(IApplicationDbContext context)
        {

            try
            {
                if (!context.Categories.Any())
                {
                    var categories = new List<Category>() {
                        new Category { Id = 1, Title = "Computers" },
                        new Category { Id = 2, Title = "Mobile Phones" },
                        new Category { Id = 3, Title = "Headphones" }
                    };
                    context.Categories.AddRange(categories);
                }

                if (!context.Products.Any())
                {
                    var products = new List<Product>() {
                        new Product { Id = 1, Title = "MacBook Pro", Description = "13-inch MacBook Pro with M1 chip", Price = 1499, CategoryId = 1 },
                        new Product { Id = 2, Title = "iPhone 13", Description = "Apple's latest iPhone with A15 Bionic chip", Price = 799, CategoryId = 2 },
                        new Product { Id = 3, Title = "Samsung Galaxy S21", Description = "Samsung's flagship phone with Exynos 2100 chip", Price = 699, CategoryId = 2 },
                        new Product { Id = 4, Title = "Sony WH-1000XM4", Description = "Noise-cancelling headphones with Alexa support", Price = 349, CategoryId = 3 },
                        new Product { Id = 5, Title = "Bose QuietComfort 35", Description = "Wireless noise-cancelling headphones", Price = 299, CategoryId = 3 }
                    };
                    context.Products.AddRange(products);
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
