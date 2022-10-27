using OutBoundService.Models.Dto;

namespace OutBoundService.Repository.Interface
{
    public interface ICustomerOrderRespository
    {
        Task<CustomerOrderDto> CreateUpdateCustomerOrder(CustomerOrderDto customerOrderDto);
        Task<IList<CustomerOrderDto>> GetAllOrders();
        Task<CustomerOrderDto> GetCustomerOrderById(int customerOrderId);
        Task<bool> DeleteCustomerOrder(int customerOrderId);
        Task<CustomerOrderDto> StatusUpdateCustomerOrder(int customerOrderId, string status);
    }
}
