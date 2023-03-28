using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
