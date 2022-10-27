using InventoryManagementService.Models.Dto;

namespace InventoryManagementService.Repository.Interface
{
    public interface IProductRepository
    {
        Task<IList<ProductDto>> GetAllProduct();
        Task<IList<ProductDto>> SearchProductByName(string name);
        Task<HttpResponseMessage> UpdateProduct(ProductDto productDto);
    }
}
