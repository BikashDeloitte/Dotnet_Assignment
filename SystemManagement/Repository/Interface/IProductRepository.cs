using Microsoft.AspNetCore.Mvc;
using SystemManagement.Models.Dto;

namespace SystemManagement.Repository.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> GetProductById(int productId);
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
        Task<bool> DeleteProduct(int productId);
        ActionResult<bool> CheckProductById(int id);
        Task<ProductDto> UpdateProductPriority(int id, int priority);
    }
}
