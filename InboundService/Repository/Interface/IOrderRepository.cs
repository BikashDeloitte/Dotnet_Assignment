using InboundService.Models.Dto;

namespace InboundService.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDto>> GetAllOrders();
        Task<OrderDto> GetOrderById(int orderId);
        Task<OrderDto> CreateUpdateOrder(OrderDto orderDto);
        Task<bool> DeleteOrder(int orderId);
        Task<OrderDto> StatusUpdateOrder(int orderId, string status);
    }
}
