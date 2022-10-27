using InventoryManagementService.Models.Dto;

namespace InventoryManagementService.Repository.Interface
{
    public interface IProductRepository
    {
        Task<IList<ProductDto>> GetAllProduct();
    }
}
