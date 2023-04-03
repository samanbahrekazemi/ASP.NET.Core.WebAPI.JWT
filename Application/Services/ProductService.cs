using Application.DTOs;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ProductService : IProductService
    {

        private readonly IApplicationDbContext _context;

        public ProductService(IApplicationDbContext context)
        {
            _context = context;
        }
        public void AddProduct(ProductDTO productDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            return await _context.Products.Include(a => a.Category).Select(x=> new ProductDTO() { Title = x.Title, Price = x.Price, Category = x.Category.Title }).ToListAsync();
        }

        public ProductDTO GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(ProductDTO productDto)
        {
            throw new NotImplementedException();
        }
    }
}
