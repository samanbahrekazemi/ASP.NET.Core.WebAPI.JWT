using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : IdentityUser<string>
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;

        public ICollection<UserRole> UserRoles { get; set; }

    }
}
