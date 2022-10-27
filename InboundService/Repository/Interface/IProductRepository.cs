using InboundService.Models.Dto;

namespace InboundService.Repository.Interface
{
    public interface IProductRepository
    {
        Task<ProductDto> GetProduct(int id);
        Task<ProductDto> UpdateProductPriority(int id, int priority);
    }
}
