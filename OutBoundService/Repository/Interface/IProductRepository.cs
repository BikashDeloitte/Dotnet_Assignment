using OutBoundService.Models.Dto;

namespace OutBoundService.Repository.Interface
{
    public interface IProductRepository
    {
        Task<ProductDto> UpdateProductPriority(int id, int priority);
        Task<ProductDto> GetProductById(int id);
    }
}
