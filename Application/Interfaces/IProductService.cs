using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int id);
        void AddProduct(ProductDTO productDto);
        void UpdateProduct(ProductDTO productDto);
        void DeleteProduct(int id);
    }
}
