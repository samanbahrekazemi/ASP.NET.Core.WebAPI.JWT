using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class UserRole : IdentityUserRole<string>
    {

        public override string RoleId { get; set; }
        public Role Role { get; set; }

        public override string UserId { get; set; }
        public User User { get; set; }

    }
}
